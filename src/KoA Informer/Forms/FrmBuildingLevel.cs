#region [   Usings   ]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Koa.Model;

#endregion

namespace KoA_Informer.Forms
{
    public partial class FrmBuildingLevel : Form
    {
        public FrmBuildingLevel()
        {
            InitializeComponent();


            DataBase.Executar<Building>((db, col) =>
            {
                Buildings =
                    col.FindAll()
                        .ToList();
            });

            DataBase.Executar<Material>((db, col) =>
            {
                Materials =
                    col.FindAll()
                        .ToList();
            });
        }

        public BuildingLevel BuildingLevel
        {
            get => BsDados.Current as BuildingLevel;
            set => BsDados.DataSource = new[] { value };
        }

        private IList<Building> Buildings { get; set; }
        private IList<Material> Materials { get; set; }

        private void BsData_CurrentChanged(object sender, EventArgs e)
        {
            if (BsDados.Current is BuildingLevel buildingLevel)
            {
                BsBuiding.DataSource = new[] { buildingLevel.Building };

                OpenBuildingRequirements();
                OpenMateriallRequirements();
            }
        }

        private void OpenBuildingRequirements()
        {
            if (BsDados.Current is BuildingLevel buildingLevel)
            {
                DataBase.Executar<BuildingRequirement>((db, col) =>
                {
                    var teste =
                        col
                            .Include(a => a.Requirement)
                            .Find(a => a.BuildingLevel.Id == buildingLevel.Id)
                            //.Select(a => a.Requirement)
                            .ToList();


                    BsBuildRequirements.DataSource =
                        col
                            .Include(a => a.Requirement)
                            .Find(a => a.BuildingLevel.Id == buildingLevel.Id)
                            .Select(a => a.Requirement)
                            .ToList();
                });
            }

        }

        private void OpenMateriallRequirements()
        {
            if (BsDados.Current is BuildingLevel buildingLevel)
            {
                DataBase.Executar<MaterialRequirement>((db, col) =>
                {
                    BsBuildMaterials.DataSource =
                        col
                            .Include(a => a.Material)
                            .Find(a => a.BuildingLevel.Id == buildingLevel.Id)
                            ///.Select(a => a.Material)
                            .ToList();
                });
            }

        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            DataBase.Executar<BuildingLevel>((db, col) =>
            {
                if (BsDados.Current is BuildingLevel item)
                    col.Upsert(item);
            });
            DataBase.Executar<Building>((db, col) =>
            {
                var build = col
                    .Include(a => a.Levels)
                    .FindById(BuildingLevel.Building.Id);
                if (!(build.Levels?.Contains(BuildingLevel) ?? false))
                {
                    build.Levels.Add(BuildingLevel);

                    col.Upsert(build);
                }
            });
        }

        private void BtnNewBuildRequirement_Click(object sender, EventArgs e)
        {
            if (BsDados.Current is BuildingLevel building)
            {
                var form = new FrmBuildingRequirement
                {
                    BuildingRequirement = new BuildingRequirement
                    {
                        BuildingLevel = building
                    }
                };
                form.ShowDialog(this);
                OpenBuildingRequirements();
            }
        }

        private void BtnNewMaterial_Click(object sender, EventArgs e)
        {
            if (BsDados.Current is BuildingLevel building)
            {
                var form = new FrmMaterialRequirement
                {
                    MaterialRequirement = new MaterialRequirement
                    {
                        BuildingLevel = building
                    }
                };
                form.ShowDialog(this);
                OpenMateriallRequirements();
            }
        }

        private void FrmBuildingLevel_Load(object sender, EventArgs e)
        {
        }

        private void GridBuildRequirements_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == Building.Index && e.Value != null)
                e.Value = Buildings.First(a => a.Id.Equals(((Building)e.Value).Id));
        }

        private void GridMaterialRequirements_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColMaterial.Index)
                e.Value = Materials.First(a => a.Id.Equals(((Material)e.Value).Id));
        }

        private void BtnDelMaterial_Click(object sender, EventArgs e)
        {
            DataBase.Executar<BuildingRequirement>((db, col) =>
            {
                foreach (var linha in GridBuildRequirements.Selecteds<BuildingRequirement>())
                {
                    col.Delete(linha.Id);
                }
            });
            OpenBuildingRequirements();
        }

        private void BtnDelBuildRequirement_Click(object sender, EventArgs e)
        {
            DataBase.Executar<BuildingLevel>((db, col) =>
            {
                foreach (var linha in GridBuildRequirements.Selecteds<BuildingLevel>())
                {
                    col.Delete(linha.Id);
                }
            });
            OpenBuildingRequirements();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<T> Selecteds<T>(this DataGridView grid)
        {

            for (var index = 0; index < grid.SelectedRows.Count; index++)
            {
                var selectedRow = grid.SelectedRows[index];
                yield return (T)selectedRow.DataBoundItem;
            }
        }
    }

}