using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORMULARIO_MDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuStrip oMenuStrip = new MenuStrip();

            List<Menu> oListaMenu = new List<Menu>()
            {
                new Menu()
                {
                    nombre = "Crear",
                    oSubMenu = new List<SubMenu>(){
                        new SubMenu()
                        {
                            nombre = "Personas"
                        },
                        new SubMenu()
                        {
                            nombre = "Empleados"
                        }
                    }
                },
                new Menu()
                {
                    nombre = "Reporte",
                    oSubMenu = new List<SubMenu>(){
                        new SubMenu()
                        {
                            nombre = "Ventas"
                        }
                    }
                },
                new Menu()
                {
                    nombre = "Otros"
                }
            };


            foreach(Menu oMenu in oListaMenu)
            {
                ToolStripMenuItem oMenuItem = new ToolStripMenuItem(oMenu.nombre);

                if(oMenu.oSubMenu != null)
                {
                    //pintamos los submenus
                    foreach (SubMenu oSubMenu in oMenu.oSubMenu)
                    {
                        ToolStripMenuItem oSubMenuItem = new ToolStripMenuItem(oSubMenu.nombre,null,submenu_selected);
                        oMenuItem.DropDownItems.Add(oSubMenuItem);
                    }
                }

                oMenuStrip.Items.Add(oMenuItem);
            }





            this.MainMenuStrip = oMenuStrip;
            Controls.Add(oMenuStrip);



        }

        private void submenu_selected(object sender, System.EventArgs e)
        {
            MessageBox.Show(string.Concat("Le diste click en el menu '", sender.ToString(), "'"), "Menu Items Event",
                                                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public class Menu
        {
            public string nombre { get; set; }
            public List<SubMenu> oSubMenu { get; set; }
        }

        public class SubMenu
        {
            public string nombre { get; set; }
        }



    }
}
