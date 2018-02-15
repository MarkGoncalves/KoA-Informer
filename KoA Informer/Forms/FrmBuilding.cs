using System.Linq;
using System.Windows.Forms;
using Koa.Model;

namespace KoA_Informer.Forms
{
    public partial class FrmBuilding : Form
    {
        public FrmBuilding()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            DataBase.Executar<Building>((db, col) =>
            {
                var lista = col
                            .Include(a => a.Levels)
                            .FindAll()
                            .OrderBy(a => a.Name)
                            .ToList();

                BsDados.DataSource = lista;

                if (!lista.Any())
                    db.DropCollection(col.Name);
            });
        }

        private void BtnGravar_Click(object sender, System.EventArgs e)
        {
            DataBase.Executar<Building>((db, col) =>
            {
                if (BsDados.Current is Building item)
                    col.Upsert(item);
            });
            Listar();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            DataBase.Executar<Building>((db, col) =>
            {
                if (BsDados.Current is Building item)
                    col.Delete(item.Id);
            });

            Listar();
        }

        private void FrmBuilding_Load(object sender, System.EventArgs e)
        {
            Listar();
        }

        private void BtnNewLevel_Click(object sender, System.EventArgs e)
        {
            if (BsDados.Current is Building building)
            {
                var form = new FrmBuildingLevel
                {
                    BuildingLevel = new BuildingLevel
                    {
                        Building = building
                    }
                };
                form.ShowDialog(this);
                OpenLevels();
            }
        }

        private void OpenLevels()
        {
            if (BsDados.Current is Building building)

                DataBase.Executar<BuildingLevel>((db, col) =>
                {
                    var lista = col
                        .FindAll()
                        .Where(a => a.Building.Id == building.Id)
                        .OrderBy(a => a.Level)
                        .ToList();

                    BsLeveis.DataSource = lista;

                });
        }

        private void BsDados_CurrentChanged(object sender, System.EventArgs e)
        {
            OpenLevels();
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            if (!(BsLeveis.Current is BuildingLevel buildingLevel)) return;

            var form = new FrmBuildingLevel
            {
                BuildingLevel = buildingLevel
            };
            form.Show();
        }

        private void BtnErase_Click(object sender, System.EventArgs e)
        {
            DataBase.Executar<BuildingLevel>((db, col) =>
            {
                if (BsLeveis.Current is BuildingLevel buildingLevel)
                    col.Delete(buildingLevel.Id);
            });
            OpenLevels();
        }
    }
}