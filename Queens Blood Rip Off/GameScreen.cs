using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queens_Blood_Rip_Off
{
    public partial class GameScreen : UserControl
    {
        public static int tileNum;
        public static int boostUNum1;
        public static int boostUNum2;
        public static int boostDNum1;
        public static int boostDNum2;

        int p1Score = 0;
        int p2Score = 0;
        int timer = 0;
        int rank;

        string row1, row2, row3;
        public static int p1r1, p2r1, p1r2, p2r2, p1r3, p2r3;
        public static List<Tiles> tile = new List<Tiles>();

        Pen bPen = new Pen(Color.Black, 3);
        Pen grPen = new Pen(Color.Gray, 3);
        Pen rPen = new Pen(Color.Red, 3);
        Pen gPen = new Pen(Color.Green, 3);

        List<Card> p1Deck = new List<Card>();
        public static List<Card> p1Hand = new List<Card>();
        List<Card> p2Deck = new List<Card>();
        public static List<Card> p2Hand = new List<Card>();

        Random rng = new Random();
        public static bool p1Turn = true;
        bool p1CanPlay, p2CanPlay;
        bool endGame = false;
       
        SolidBrush brush;

        Rectangle mouse = new Rectangle(MousePosition.X, MousePosition.Y, 10, 10);

        string newCard;

        public GameScreen()
        {
            InitializeComponent();

            //Cursor.Hide();

            p1Deck = DeckScreen.p1Deck;
            p2Deck = DeckScreen.p2Deck;


            #region Making Tiles 
            int pawn;
            int x = 280;
            int y = 20;
            for (int i = 1; i <= 15; i++)
            {
                if (i == 1 || i == 5 || i == 6 || i == 10 || i == 11 || i == 15)
                {
                    pawn = 2;
                }
                else
                {
                    pawn = 0;
                }

                tile.Add(new Tiles(pawn, "NA", new Rectangle(x, y, 94, 159)));
                x += 100;

                if (i % 5 == 0)
                {
                    x = 280;
                    y += 165;
                }
            }

            tile[0].player = tile[5].player = tile[10].player = "P1";
            tile[4].player = tile[9].player = tile[14].player = "P2";
            #endregion

            #region P1 Deck
            //AddCard(Form1.SO, p1Deck, "P1");
            //AddCard(Form1.SO, p1Deck, "P1");
            //AddCard(Form1.JUS, p1Deck, "P1");
            //AddCard(Form1.JUS, p1Deck, "P1");
            //AddCard(Form1.CC, p1Deck, "P1");
            //AddCard(Form1.CC, p1Deck, "P1");
            //AddCard(Form1.Ca, p1Deck, "P1");
            //AddCard(Form1.Ca, p1Deck, "P1");
            //AddCard(Form1.Le, p1Deck, "P1");
            //AddCard(Form1.Le, p1Deck, "P1");
            //AddCard(Form1.CM, p1Deck, "P1");
            //AddCard(Form1.If, p1Deck, "P1");
            //AddCard(Form1.GW, p1Deck, "P1");
            //AddCard(Form1.GW, p1Deck, "P1");
            //AddCard(Form1.El, p1Deck, "P1");
            //AddCard(Form1.MF, p1Deck, "P1");
            //AddCard(Form1.MF, p1Deck, "P1");
            //AddCard(Form1.TK, p1Deck, "P1");
            //AddCard(Form1.TK, p1Deck, "P1");
            //AddCard(Form1.MF, p1Deck, "P1");
            //AddCard(Form1.SP, p1Deck, "P1");
            //AddCard(Form1.SP, p1Deck, "P1");
            //AddCard(Form1.Ma, p1Deck, "P1");
            //AddCard(Form1.GH, p1Deck, "P1");
            //AddCard(Form1.HS, p1Deck, "P1");
            #endregion

            #region P2 Deck
            //AddCard(Form1.SO, p2Deck, "P2");
            //AddCard(Form1.SO, p2Deck, "P2");
            //AddCard(Form1.JUS, p2Deck, "P2");
            //AddCard(Form1.JUS, p2Deck, "P2");
            //AddCard(Form1.CC, p2Deck, "P2");
            //AddCard(Form1.CC, p2Deck, "P2");
            //AddCard(Form1.Ca, p2Deck, "P2");
            //AddCard(Form1.Ca, p2Deck, "P2");
            //AddCard(Form1.Le, p2Deck, "P2");
            //AddCard(Form1.Le, p2Deck, "P2");
            //AddCard(Form1.CM, p2Deck, "P2");
            //AddCard(Form1.If, p2Deck, "P2");
            //AddCard(Form1.GW, p2Deck, "P2");
            //AddCard(Form1.GW, p2Deck, "P2");
            //AddCard(Form1.El, p2Deck, "P2");
            #endregion

            for (int i = 0; i < 6; i++)
            {
                int temp = rng.Next(0, p1Deck.Count);
                AddCard(p1Deck[temp], p1Hand, "P1");
                p1Deck.RemoveAt(temp);

                temp = rng.Next(0, p2Deck.Count);
                AddCard(p2Deck[temp], p2Hand, "P2");
                p2Deck.RemoveAt(temp);
            }


        }

        private void newCardTimer_Tick(object sender, EventArgs e)
        {

            
            if (newCard == "P1")
            {
                p1Hand[p1Hand.Count - 1].r.X -= 4;
                p1Hand[p1Hand.Count - 1].r.Y += 25;

                if (p1Hand[p1Hand.Count - 1].r.Y > 548)
                {
                    gameTick.Enabled = true;
                    newCardTimer.Enabled = false;
                }
            }
            else
            {
                p2Hand[p2Hand.Count - 1].r.X += 4;
                p2Hand[p2Hand.Count - 1].r.Y += 30;

                if (p2Hand[p2Hand.Count - 1].r.Y > 548)
                {
                    gameTick.Enabled = true;
                    newCardTimer.Enabled = false;
                }
            }
            Refresh();
        }

        private void gameTick_Tick(object sender, EventArgs e)
        {
            var rp = this.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));

            mouse.Location = new Point(rp.X, rp.Y);



            if (p1Turn)
            {
                foreach (Card c in p1Hand)
                {
                    c.Move(mouse.Location.X - 25, mouse.Location.Y - 70);
                }
            }
            else
            {
                foreach (Card c in p2Hand)
                {
                    c.Move(mouse.Location.X - 25, mouse.Location.Y - 70);
                }
            }

            boostUNum1 = 0;
            foreach (Tiles t in tile)
            {
                if (t.c != null && t.player == "P1")
                {
                    if (t.effect > 0)
                    {
                        boostUNum1++;
                    }
                }
            }

            boostUNum2 = 0;
            foreach (Tiles t in tile)
            {
                if (t.c != null && t.player == "P2")
                {
                    if (t.effect > 0)
                    {
                        boostUNum2++;
                    }
                }
            }

            foreach (Tiles t in tile)
            {
                if (t.c != null)
                {
                    t.c.Effect();
                    t.power = t.c.power;
                    t.power += t.effect;

                }
            }

            #region display row score
            p1r1 = p1r2 = p1r3 = p2r1 = p2r2 = p2r3 = 0;

            foreach (Tiles t in tile)
            {
                if (t.c != null)
                {
                    if (tile.IndexOf(t) < 5)
                    {
                        if (t.player == "P1")
                        {
                            p1r1 += t.power;
                        }
                        else
                        {
                            p2r1 += t.power;
                        }
                    }
                    else if (tile.IndexOf(t) < 10)
                    {

                        if (t.player == "P1")
                        {
                            p1r2 += t.power;
                        }
                        else
                        {
                            p2r2 += t.power;
                        }
                    }
                    else
                    {

                        if (t.player == "P1")
                        {
                            p1r3 += t.power;
                        }
                        else
                        {
                            p2r3 += t.power;
                        }
                    }
                }
            }
            #endregion

            #region check if player can play a card
            if (p1Turn)
            {
                p1CanPlay = false;

                foreach (Tiles t in tile)
                {
                    if (t.player == "P1")
                    {
                        foreach (Card c in p1Hand)
                        {
                            if (t.pawns >= c.rank && t.c == null)
                            {
                                p1CanPlay = true;
                                break;
                            }
                        }
                    }

                    if (p1CanPlay)
                    {
                        break;
                    }

                }

                if (p1CanPlay == false)
                {
                    if (p2CanPlay == false)
                    {
                        skipButton.Text = "End";
                    }
                    else
                    {
                        skipButton.Text = "Skip";
                    }

                    skipButton.Visible = true;
                    skipButton.Location = new Point(887, 606);
                }
                else
                {
                    skipButton.Visible = false;
                }
            }
            else
            {
                p2CanPlay = false;

                foreach (Tiles t in tile)
                {
                    if (t.player == "P2")
                    {
                        foreach (Card c in p2Hand)
                        {
                            if (t.pawns >= c.rank && t.c == null)
                            {
                                p2CanPlay = true;
                                break;
                            }
                        }
                    }

                    if (p2CanPlay)
                    {
                        break;
                    }

                }

                if (p2CanPlay == false)
                {
                    if (p1CanPlay == false)
                    {
                        skipButton.Text = "End";
                    }
                    else
                    {
                        skipButton.Text = "Skip";
                    }

                    skipButton.Visible = true;
                    skipButton.Location = new Point(20, 606);
                }
                else
                {
                    skipButton.Visible = false;
                }
            }
            #endregion

            #region checks if cards power is 0 if so destroys it
            foreach (Tiles t in tile)
            {
                if (t.c != null && t.power <= 0)
                {
                    string effect = t.c.effect;
                    newCard = t.player;

                    t.power = 0;
                    t.Destroy();

                    if (effect == "AddCardD")
                    {
                        newCardTimer.Enabled = true;
                        gameTick.Enabled = false;
                    }
                }
            }
            #endregion

            if (endGame)
            {
                endGameTimer.Enabled = true;
                gameTick.Enabled = false;
                skipButton.Visible = false;
            }

            timer = 0;

            Refresh();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            if (p1Turn)
            {
                p1Turn = false;

                int temp = rng.Next(0, p2Deck.Count);
                if (p2Deck.Count > 0)
                {
                    AddCard(p2Deck[temp], p2Hand, "P2");
                    p2Deck.RemoveAt(temp);
                }
            }
            else
            {
                p1Turn = true;

                int temp = rng.Next(0, p1Deck.Count);
                if (p1Deck.Count > 0)
                {
                    AddCard(p1Deck[temp], p1Hand, "P1");
                    p1Deck.RemoveAt(temp);
                }
            }

            if (p1CanPlay == false && p2CanPlay == false)
            {
                #region gets winner for each row
                if (p1r1 > p2r1)
                {
                    row1 = "P1";
                }
                else if (p1r1 < p2r1)
                {
                    row1 = "P2";
                }
                else
                {
                    row1 = "Done";
                }

                if (p1r2 > p2r2)
                {
                    row2 = "P1";
                }
                else if (p1r2 < p2r2)
                {
                    row2 = "P2";
                }
                else
                {
                    row2 = "Done";
                }

                if (p1r3 > p2r3)
                {
                    row3 = "P1";
                }
                else if (p1r3 < p2r3)
                {
                    row3 = "P2";
                }
                else
                {
                    row3 = "Done";
                }
                #endregion

                endGame = true;
            }
        }

        private void endGameTimer_Tick(object sender, EventArgs e)
        {
            if (timer % 4 == 0)
            {
                #region tally row 1 score
                if (row1 == "P1")
                {
                    p1r1--;
                    p1Score++;

                    if (p1r1 == 0)
                    {
                        row1 = "Done";
                    }
                }
                else if (row1 == "P2")
                {
                    p2r1--;
                    p2Score++;

                    if (p2r1 == 0)
                    {
                        row1 = "Done";
                    }
                }
                #endregion

                #region tally row 2 score
                if (row1 == "Done")
                {
                    if (row2 == "P1")
                    {
                        p1r2--;
                        p1Score++;

                        if (p1r2 == 0)
                        {
                            row2 = "Done";
                        }
                    }
                    else if (row2 == "P2")
                    {
                        p2r2--;
                        p2Score++;

                        if (p2r2 == 0)
                        {
                            row2 = "Done";
                        }
                    }
                }
                #endregion

                #region tally row 3 score
                if (row1 == "Done" && row2 == "Done")
                {
                    if (row3 == "P1")
                    {
                        p1r3--;
                        p1Score++;

                        if (p1r3 == 0)
                        {
                            row3 = "Done";
                        }
                    }
                    else if (row3 == "P2")
                    {
                        p2r3--;
                        p2Score++;

                        if (p2r3 == 0)
                        {
                            row3 = "Done";
                        }
                    }
                }
                #endregion
            }

            timer++;
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Tiles t in tile)
            {
                if (tile.IndexOf(t) % 2 == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), t.r);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), t.r);
                }

                if (t.c == null)
                {
                    e.Graphics.DrawRectangle(bPen, t.r);
                    #region Drawing Pawns
                    if (t.pawns == 1)
                    {
                        if (t.player == "P1")
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) - 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) - 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                        }
                    }
                    else if (t.pawns == 2)
                    {
                        if (t.player == "P1")
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) - 30, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) + 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) - 30, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) + 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                        }
                    }
                    else if (t.pawns == 3)
                    {
                        if (t.player == "P1")
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) - 30, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) + 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), t.r.X + (t.r.Width / 2) - 10, t.r.Y + (t.r.Height / 2) + 20, 20, 20);
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) - 30, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) + 10, t.r.Y + (t.r.Height / 2) - 10, 20, 20);
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), t.r.X + (t.r.Width / 2) - 10, t.r.Y + (t.r.Height / 2) + 20, 20, 20);
                        }
                    }
                    #endregion
                }
                else
                {
                    e.Graphics.DrawImage(t.c.img, t.r);
                    e.Graphics.DrawRectangle(bPen, t.r);

                    if (t.player == "P1")
                    {
                        brush = new SolidBrush(Color.Blue);
                    }
                    else
                    {
                        brush = new SolidBrush(Color.Red);
                    }
                    if (t.power < 10)
                    {
                        Font f = new Font(new FontFamily("Segoe Print"), 17, FontStyle.Bold, GraphicsUnit.Pixel);
                        e.Graphics.DrawString($"{t.power}", f, brush, t.r.X + 69, t.r.Y + 3);
                    }
                    else
                    {
                        Font f = new Font(new FontFamily("Segoe Print"), 10, FontStyle.Bold, GraphicsUnit.Pixel);
                        e.Graphics.DrawString($"{t.power}", f, brush, t.r.X + 69, t.r.Y + 10);
                    }
                }


                if (t.effect > 0)
                {
                    e.Graphics.DrawRectangle(gPen, t.r);
                }
                else if (t.effect < 0)
                {
                    e.Graphics.DrawRectangle(rPen, t.r);
                }
            }

            e.Graphics.DrawRectangle(new Pen(Color.Black), mouse);


            if (endGame == false && gameTick.Enabled == true)
            {
                if (p1Turn)
                {
                    int x = 12;
                    foreach (Card c in p1Hand)
                    {
                        Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                        if (c.holding == false)
                        {
                            c.r = new Rectangle(x, 548, 84, 128);
                        }

                        e.Graphics.DrawImage(c.img, c.r);
                        e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                        x += 86;
                    }
                }
                else
                {
                    int x = 990;

                    foreach (Card c in p2Hand)
                    {


                        Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                        if (c.holding == false)
                        {
                            c.r = new Rectangle(x, 548, 84, 128);
                        }

                        e.Graphics.DrawImage(c.img, c.r);
                        e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                        x -= 86;
                    }
                }
            }
            else
            {
                Card c;
                if (newCard == "P1")
                {
                    c = p1Hand[p1Hand.Count - 1];
                }
                else
                {
                    c = p2Hand[p2Hand.Count - 1];
                }

                e.Graphics.DrawImage(c.img, c.r);
            }

            int y = 71;

            #region score 
            for (int i = 0; i < 4; i++)
            {
                Rectangle temp = new Rectangle(200, y, 60, 60);
                Rectangle temp2 = new Rectangle(840, y, 60, 60);

                Font f = new Font(new FontFamily("Segoe Print"), 30, FontStyle.Bold, GraphicsUnit.Pixel);


                switch (i)
                {
                    case 0:
                        if (p1r1 > p2r1)
                        {
                            e.Graphics.DrawEllipse(bPen, temp);
                            e.Graphics.DrawString($"{p1r1}", f, new SolidBrush(Color.Black), temp.X + 15, temp.Y);
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r1}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                        }
                        else
                        {
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r1}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                            if (p2r1 > p1r1)
                            {
                                e.Graphics.DrawEllipse(bPen, temp2);
                                e.Graphics.DrawString($"{p2r1}", f, new SolidBrush(Color.Black), temp2.X + 15, temp2.Y);

                            }
                            e.Graphics.DrawEllipse(grPen, temp);
                            e.Graphics.DrawString($"{p1r1}", f, new SolidBrush(Color.Gray), temp.X + 15, temp.Y);
                        }
                        break;
                    case 1:
                        if (p1r2 > p2r2)
                        {
                            e.Graphics.DrawEllipse(bPen, temp);
                            e.Graphics.DrawString($"{p1r2}", f, new SolidBrush(Color.Black), temp.X + 15, temp.Y);
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r2}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                        }
                        else
                        {
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r2}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                            if (p2r2 > p1r2)
                            {
                                e.Graphics.DrawEllipse(bPen, temp2);
                                e.Graphics.DrawString($"{p2r2}", f, new SolidBrush(Color.Black), temp2.X + 15, temp2.Y);

                            }
                            e.Graphics.DrawEllipse(grPen, temp);
                            e.Graphics.DrawString($"{p1r2}", f, new SolidBrush(Color.Gray), temp.X + 15, temp.Y);
                        }
                        break;
                    case 2:
                        if (p1r3 > p2r3)
                        {
                            e.Graphics.DrawEllipse(bPen, temp);
                            e.Graphics.DrawString($"{p1r3}", f, new SolidBrush(Color.Black), temp.X + 15, temp.Y);
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r3}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                        }
                        else
                        {
                            e.Graphics.DrawEllipse(grPen, temp2);
                            e.Graphics.DrawString($"{p2r3}", f, new SolidBrush(Color.Gray), temp2.X + 15, temp2.Y);

                            if (p2r3 > p1r3)
                            {
                                e.Graphics.DrawEllipse(bPen, temp2);
                                e.Graphics.DrawString($"{p2r3}", f, new SolidBrush(Color.Black), temp2.X + 15, temp2.Y);

                            }
                            e.Graphics.DrawEllipse(grPen, temp);
                            e.Graphics.DrawString($"{p1r3}", f, new SolidBrush(Color.Gray), temp.X + 15, temp.Y);
                        }
                        break;
                }

                y += 160;
            }
            #endregion

            if (endGame)
            {
                Rectangle p1ScoreRec = new Rectangle((this.Width / 2) - 200, (this.Height / 2) - 100, 100, 100);
                Rectangle p2ScoreRec = new Rectangle((this.Width / 2) + 50, (this.Height / 2) - 100, 100, 100);
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), p1ScoreRec);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), p2ScoreRec);
                e.Graphics.DrawEllipse(bPen, p1ScoreRec);
                e.Graphics.DrawEllipse(bPen, p2ScoreRec);

                Font f = new Font(new FontFamily("Segoe Print"), 40, FontStyle.Bold, GraphicsUnit.Pixel);

                if (p1Score > 9)
                {
                    e.Graphics.DrawString($"{p1Score}", f, new SolidBrush(Color.Yellow), p1ScoreRec.X + 15, p1ScoreRec.Y + 13);
                }
                else
                {
                    e.Graphics.DrawString($"{p1Score}", f, new SolidBrush(Color.Yellow), p1ScoreRec.X + 30, p1ScoreRec.Y + 13);
                }
                if (p2Score > 9)
                {
                    e.Graphics.DrawString($"{p2Score}", f, new SolidBrush(Color.Yellow), p2ScoreRec.X + 15, p2ScoreRec.Y + 13);
                }
                else
                {
                    e.Graphics.DrawString($"{p2Score}", f, new SolidBrush(Color.Yellow), p2ScoreRec.X + 30, p2ScoreRec.Y + 13);
                }
            }

        }



        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (p1Turn)
            {
                foreach (Card c in p1Hand)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                        rank = c.rank;
                    }
                }
            }
            else
            {
                foreach (Card c in p2Hand)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                        rank = c.rank;
                    }
                }
            }
        }

        private void GameScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (p1Turn)
            {
                playCard(p1Hand);
            }
            else
            {
                playCard(p2Hand);
            }

        }

        private void playCard(List<Card> hand)
        {
            foreach (Card c in hand)
            {
                if (c.holding)
                {
                    c.holding = false;
                    foreach (Tiles t in tile)
                    {
                        if (mouse.IntersectsWith(t.r))
                        {
                            if (rank <= t.pawns && t.c == null && t.player == c.player && c.effect != "Replace")
                            {
                                t.c = c;
                                t.play();

                                hand.Remove(c);
                                if (p1Turn)
                                {
                                    p1Turn = false;

                                    int temp = rng.Next(0, p2Deck.Count);
                                    if (p2Deck.Count > 0)
                                    {
                                        AddCard(p2Deck[temp], p2Hand, "P2");
                                        p2Deck.RemoveAt(temp);
                                    }
                                }
                                else
                                {
                                    p1Turn = true;

                                    int temp = rng.Next(0, p1Deck.Count);
                                    if (p1Deck.Count > 0)
                                    {
                                        AddCard(p1Deck[temp], p1Hand, "P1");
                                        p1Deck.RemoveAt(temp);
                                    }

                                }

                                newCard = t.player;
                                if (c.effect == "AddCardU")
                                {
                                    newCardTimer.Enabled = true;
                                    gameTick.Enabled = false;
                                }

                                break;
                            }
                            else if (c.effect == "Replace" && t.c != null)
                            {
                                t.Destroy();
                                t.c = c;
                                t.play();
                                hand.Remove(c);

                                if (p1Turn)
                                {
                                    p1Turn = false;

                                    int temp = rng.Next(0, p2Deck.Count);
                                    if (p2Deck.Count > 0)
                                    {
                                        AddCard(p2Deck[temp], p2Hand, "P2");
                                        p2Deck.RemoveAt(temp);
                                    }
                                }
                                else
                                {
                                    p1Turn = true;

                                    int temp = rng.Next(0, p1Deck.Count);
                                    if (p1Deck.Count > 0)
                                    {
                                        AddCard(p1Deck[temp], p1Hand, "P1");
                                        p1Deck.RemoveAt(temp);
                                    }

                                }

                                newCard = t.player;
                                if (c.effect == "AddCardU")
                                {
                                    newCardTimer.Enabled = true;
                                    gameTick.Enabled = false;
                                }

                                break;
                            }
                        }
                    }
                    break;
                }
            }

        }


        public static void AddCard(Card c, List<Card> deck, string p)
        {
            deck.Add(new Card(c.basePower, c.rank, c.pawnTiles, c.effectTiles, c.img, c.effect, c.rarity));
            deck[deck.Count - 1].player = p;
        }

        
    }
}
