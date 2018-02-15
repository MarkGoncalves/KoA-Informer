using System.Linq;
using System.Windows.Forms;
using Koa.Model;

namespace KoA_Informer.Forms
{
    public partial class FrmMaterial : Form
    {
        public FrmMaterial()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            DataBase.Executar<Material>((db, col) =>
            {
                var lista = col.FindAll().ToList();
                BsMaterial.DataSource = lista;
                if (!lista.Any())
                    db.DropCollection(col.Name);
            });
        }

        private void BtnGravar_Click(object sender, System.EventArgs e)
        {
            DataBase.Executar<Material>((db, col) =>
            {
                if (BsMaterial.Current is Material item)
                    col.Upsert(item);
            });
            Listar();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            DataBase.Executar<Material>((db, col) =>
            {
                if (BsMaterial.Current is Material item)
                    col.Delete(item.Id);
            });

            Listar();
        }

        private void FrmMaterial_Load(object sender, System.EventArgs e)
        {
            Listar();
        }
    }
}