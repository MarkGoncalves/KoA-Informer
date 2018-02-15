#region [   Usings   ]

using System;
using System.Linq;
using System.Windows.Forms;
using Koa.Model;

#endregion

namespace KoA_Informer.Forms
{
    public partial class FrmBuildingRequirement : Form
    {
        public FrmBuildingRequirement()
        {
            InitializeComponent();

            DataBase.Executar<Building>((db, col) =>
            {
                var lista = col
                    .Include(a => a.Levels)
                    .FindAll()
                    .OrderBy(a => a.Name)
                    .ToList();

                CbBuildings.DataSource = lista;
            });
        }

        public BuildingRequirement BuildingRequirement
        {
            get => BsDados.Current as BuildingRequirement;
            set => BsDados.DataSource = new[] { value };
        }

        private void BsDados_CurrentChanged(object sender, EventArgs e)
        {
            if (BsDados.Current is BuildingRequirement buildingLevel)
                BsBuidingLevel.DataSource = new[] { buildingLevel.BuildingLevel };
        }

        private void CbBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuildings.SelectedItem is Building building)
                DataBase.Executar<BuildingLevel>((db, col) =>
                {
                    var lista = col
                        .Find(a => a.Building.Id == building.Id)
                        .ToList();

                    CbLeveis.DataSource = lista;
                });
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            DataBase.Executar<BuildingRequirement>((db, col) =>
            {
                if (BsDados.Current is BuildingRequirement item)
                    col.Upsert(item);
            });
            DataBase.Executar<BuildingLevel>((db, col) =>
            {
                var build = col
                    .Include(a => a.Requirements)
                    .FindById(BuildingRequirement.BuildingLevel.Id);
                if (!(build.Requirements?.Contains(BuildingRequirement) ?? false))
                {
                    build.Requirements.Add(BuildingRequirement);

                    col.Upsert(build);
                }
            });

            DialogResult = DialogResult.OK;
        }
    }
}