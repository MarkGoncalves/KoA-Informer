#region [   Usings   ]

using System;
using System.Linq;
using System.Windows.Forms;
using Koa.Model;

#endregion

namespace KoA_Informer.Forms
{
    public partial class FrmMaterialRequirement : Form
    {
        public FrmMaterialRequirement()
        {
            InitializeComponent();

            DataBase.Executar<Material>((db, col) =>
            {
                var lista = col
                    .FindAll()
                    .OrderBy(a => a.Name)
                    .ToList();

                CbMaterial.DataSource = lista;
            });
        }

        public MaterialRequirement MaterialRequirement
        {
            get => BsDados.Current as MaterialRequirement;
            set => BsDados.DataSource = new[] { value };
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            DataBase.Executar<MaterialRequirement>((db, col) =>
            {
                if (BsDados.Current is MaterialRequirement item)
                    col.Upsert(item);
            });
            DataBase.Executar<BuildingLevel>((db, col) =>
            {
                var build = col
                    .Include(a => a.Materials)
                    .FindById(MaterialRequirement.BuildingLevel.Id);

                if (!(build.Materials?.Contains(MaterialRequirement) ?? false))
                {
                    build.Materials.Add(MaterialRequirement);

                    col.Upsert(build);
                }
            });

            DialogResult = DialogResult.OK;
        }
    }
}