using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queens_Blood_Rip_Off
{
    public partial class Form1 : Form
    {
        List<Point> p = new List<Point>();
        List<Point> e = new List<Point>();
        public static List<Card> cardList = new List<Card>();

        public static Card SO;
        public static Card JUS;
        public static Card CC;
        public static Card Ca;
        public static Card Le;
        public static Card CM;
        public static Card If;
        public static Card GW;
        public static Card El;
        public static Card TK;
        public static Card MF;
        public static Card HS;
        public static Card HSM;
        public static Card Ma;
        public static Card MaM;
        public static Card SP;
        public static Card GH;
        public Form1()
        {
            InitializeComponent();

            #region making each card
            p.Add(new Point(0, -1));
            p.Add(new Point(-1, 0));
            p.Add(new Point(1, 0));
            p.Add(new Point(0, 1));

            SO = new Card(1, 1, p, e, Properties.Resources.Security_Officer, "NA", "");

            p.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(1, -1));
            p.Add(new Point(0, 1));
            p.Add(new Point(1, 1));

            JUS = new Card(2, 2, p, e, Properties.Resources.J_Unit_Sweeper, "NA", "");

            p.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(1, 0));
            p.Add(new Point(-1, 0));
            e.Add(new Point(0, -1));

            CC = new Card(1, 1, p, e, Properties.Resources.Crystalline_Crab, "UP", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(1, 0));
            p.Add(new Point(0, 1));
            e.Add(new Point(1, 2));

            Ca = new Card(1, 1, p, e, Properties.Resources.Cactuar, "UP", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(1, 0));
            p.Add(new Point(0, 1));

            Le = new Card(2, 1, p, e, Properties.Resources.Levrikon, "NA", "");

            p.Clear();

            p.Add(new Point(1, 0));
            p.Add(new Point(0, -1));
            p.Add(new Point(0, 1));

            CM = new Card(1, 1, p, e, Properties.Resources.Chocobo_And_Moogle, "BoostUp", "Leg");

            p.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(0, 1));

            If = new Card(5, 3, p, e, Properties.Resources.Ifrit, "BoostUp", "Leg");

            p.Clear(); 
            p.Add(new Point(0, -1));
            p.Add(new Point(1, 0));

            GW = new Card(2, 1, p, e, Properties.Resources.Grasslands_Wolf, "NA", "");

            p.Clear();
            p.Add(new Point(0, -1));
            p.Add(new Point(0, 1));
            p.Add(new Point(-1, 0));

            El = new Card(4, 2, p, e, Properties.Resources.Elphadunk, "NA", "");

            p.Clear();
            p.Add(new Point(1, 0));

            TK = new Card(1, 2, p, e, Properties.Resources.Tonberry_King, "BoostDown", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(1, -1));
            p.Add(new Point(0, 1));

            e.Add(new Point(0, -1));
            e.Add(new Point(1, -1));
            e.Add(new Point(0, 1));
            e.Add(new Point(1, 1));

            MF = new Card(1, 2, p, e, Properties.Resources.Mindflayer, "Down", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(-1, 0));
            p.Add(new Point(1, 0));
            p.Add(new Point(0, 1));

            HS = new Card(1, 1, p, e, Properties.Resources.Heatseeker, "AddCardD", "");
            HSM = new Card(1, 1, p, e, Properties.Resources.Heatseeker_M, "NA", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(0, 1));
            p.Add(new Point(1, 0));

            Ma = new Card(1, 1, p, e, Properties.Resources.Mandragora, "AddCardU", "");
            MaM = new Card(1, 1, p, e, Properties.Resources.Mandragora_M, "NA", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(0, -1));
            p.Add(new Point(1, 0));

            e.Add(new Point(0, -1));
            e.Add(new Point(1, 0));

            SP = new Card(1, 1, p, e, Properties.Resources.Sandhog_Pie, "DeathBoost", "");

            p.Clear();
            e.Clear();

            p.Add(new Point(0, 1));
            p.Add(new Point(1, 0));

            GH = new Card(3, 1000, p, e, Properties.Resources.Grandhorn, "Replace", "");
            #endregion

            #region adding each card to a list
            cardList.Add(SO);
            cardList.Add(JUS);
            cardList.Add(CC);
            cardList.Add(Ca);
            cardList.Add(Le);
            cardList.Add(CM);
            cardList.Add(If);
            cardList.Add(GW);
            cardList.Add(El);
            cardList.Add(TK);
            cardList.Add(MF);
            cardList.Add(HS);
            cardList.Add(Ma);
            cardList.Add(SP);
            cardList.Add(GH);
            #endregion

            ChangeScreen(this, new TitleScreen());
        }




        public static void ChangeScreen(object sender, UserControl next)

        {

            Form f; // will either be the sender or parent of sender 



            if (sender is Form)

            {

                f = (Form)sender;

            }

            else

            {

                UserControl current = (UserControl)sender;

                f = current.FindForm();

                f.Controls.Remove(current);

            }



            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,

                (f.ClientSize.Height - next.Height) / 2);



            f.Controls.Add(next);

            next.Focus();

        }
    }
}
