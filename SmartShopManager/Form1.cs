using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShopManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void CompleteCbo() 
        {
            cboCat.Items.Clear();
            List<string> categoriasFiltradas = new List<string>();

            products.ForEach(elementos =>
            {
                if (!categoriasFiltradas.Contains(elementos["cate"]))
                {
                   
                    categoriasFiltradas.Add(elementos["cate"].ToString());
                }
            });

            categoriasFiltradas.ForEach(elem =>
            {
                cboCat.Items.Add(elem.ToString());
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CompleteCbo();
           columns.ForEach(elementos =>
                  {
                dgvShow.Columns.Add($"col{elementos}", elementos.ToString());
                   });
        }
        List<string> columns = new List<string>() { "Product", "Quantity", "Tot" };
        List<string> categories = new List<string>() { "Clothes", "Electronics", "Home" };

         List<Dictionary<string, object>> products = new List<Dictionary<string, object>>() {
            new Dictionary<string, object> { { "name", "Shirt" }, { "cate", "Clothes" }, { "price", 123 }, { "desc", "Gray shirt" } },
           new Dictionary<string, object> { { "name", "Pants" }, { "cate", "Clothes" }, { "price", 150 }, { "desc", "Casual pants" } },
           new Dictionary<string, object> { { "name", "Jacket" }, { "cate", "Clothes" }, { "price", 200 }, { "desc", "Windbreaker jacket" } },

            new Dictionary<string, object> { { "name", "Keyboard" }, { "cate", "Electronics" }, { "price", 80 }, { "desc", "Mechanical keyboard" } },
             new Dictionary<string, object> { { "name", "Headphones" }, { "cate", "Electronics" }, { "price", 75 }, { "desc", "Wireless headphones" } },
                 new Dictionary<string, object> { { "name", "Mouse pad" }, { "cate", "Electronics" }, { "price", 50 }, { "desc", "LED-lit mouse pad" } },

                 new Dictionary<string, object> { { "name", "Electric Oven" }, { "cate", "Home" }, { "price", 300 }, { "desc", "Small electric oven" } },
               new Dictionary<string, object> { { "name", "Robot Vacuum" }, { "cate", "Home" }, { "price", 250 }, { "desc", "Quiet with fast charging" } },
             new Dictionary<string, object> { { "name", "40'' LED TV" }, { "cate", "Home" }, { "price", 200 }, { "desc", "40'' Smart TV" } },

               new Dictionary<string, object> { { "name", "Football Boots" }, { "cate", "Sports" }, { "price", 300 }, { "desc", "Small electric oven" } },
            new Dictionary<string, object> { { "name", "Football" }, { "cate", "Sports" }, { "price", 250 }, { "desc", "Quiet with fast charging" } },
               new Dictionary<string, object> { { "name", "Boxing Gloves" }, { "cate", "Sports" }, { "price", 200 }, { "desc", "40'' Smart TV" } },
          };

        private void cboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstShow.Items.Clear();
            string selecProd = cboProd.SelectedItem.ToString();

            int index = products.FindIndex(elem => elem["name"].Equals(selecProd));

            lstShow.Items.Add($"name: {products[index]["name"]}");
            lstShow.Items.Add($"desc: {products[index]["desc"]}");
            lstShow.Items.Add($"price: ${products[index]["price"]}");
        }

        private void cboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProd.Items.Clear();
            string cateSeleccionada = cboCat.SelectedItem.ToString();

            products.ForEach(elem =>
            {
                if (elem["cate"].Equals(cateSeleccionada))
                {
                    cboProd.Items.Add(elem["name"].ToString());
                }
            });
        }
        List<Dictionary<string, object>> car = new List<Dictionary<string, object>>();
        private void btnADD_Click(object sender, EventArgs e)
        {
            string selectedProd = cboProd.SelectedItem.ToString();
            int cant = Convert.ToInt32(numericUpDown1.Value);
            int index = products.FindIndex(elem => elem["name"].Equals(selectedProd));
            int ultimoIndex = 0;
            int total = 0;

            Dictionary<string, object> aux = new Dictionary<string, object>();

            aux["name"] = products[index]["name"];
            aux["Quantity"] = cant;
            aux["price"] = products[index]["price"];

            car.Add(aux);

            ultimoIndex = car.Count - 1;

            dgvShow.Rows.Add(car[ultimoIndex]["name"], car[ultimoIndex]["Quantity"], (int)car[ultimoIndex]["price"] * (int)car[ultimoIndex]["Quantity"]);

            car.ForEach(elem =>
            {
                total += (int)elem["price"] * (int)elem["Quantity"];
            });

            lblTot.Text = $"TOT: ${total}";
        }
    }
}
