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
    public partial class DeckScreen : UserControl
    {
        public static List<Card> p1Deck = new List<Card>();
        public static List<Card> p2Deck = new List<Card>();
        List<Card> p1CardBank = new List<Card>();
        List<Card> p2CardBank = new List<Card>();
        string turn = "P1";
        Rectangle cardBankRec = new Rectangle(20, 194, 934, 484);
        Rectangle currentDeck = new Rectangle(19, 16, 1045, 173);
        Rectangle mouse;
        SolidBrush purple = new SolidBrush(Color.DarkViolet);
        SolidBrush blue = new SolidBrush(Color.Blue);
        SolidBrush red = new SolidBrush(Color.Red);
        public DeckScreen()
        {
            InitializeComponent();
            p1CardBank.Clear();
            p2CardBank.Clear();
            p1Deck.Clear();
            p2Deck.Clear();
            foreach (Card c in Form1.cardList)
            {
                if (c.rarity != "")
                {
                    AddCard(c, p1CardBank, "P1");
                    AddCard(c, p2CardBank, "P2");
                }
                else
                {
                    AddCard(c, p1CardBank, "P1");
                    AddCard(c, p1CardBank, "P1");
                    AddCard(c, p2CardBank, "P2");
                    AddCard(c, p2CardBank, "P2");
                }
            }
        }


        private void gameTick_Tick(object sender, EventArgs e)
        {
            var rp = this.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));

            mouse.Location = new Point(rp.X, rp.Y);

            if (turn == "P1")
            {
                foreach (Card c in p1CardBank)
                {
                    c.Move(mouse.Location.X - 25, mouse.Location.Y - 70);
                }
            }
            else
            {
                foreach (Card c in p2CardBank)
                {
                    c.Move(mouse.Location.X - 25, mouse.Location.Y - 70);
                }
            }

            Refresh();
        }
        private void DeckScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(purple, cardBankRec);

            if (turn == "P1")
            {

                deckSizeLabel.Text = $"{p1Deck.Count}/15";

                e.Graphics.FillRectangle(blue, currentDeck);

                int x = 27;
                int y = 197;
                foreach (Card c in p1CardBank)
                {
                    Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                    if (c.holding == false)
                    {
                        c.r = new Rectangle(x, y, 84, 128);
                    }

                    e.Graphics.DrawImage(c.img, c.r);
                    e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                    x += 93;

                    if (p1CardBank.IndexOf(c) % 9 == 0 && p1CardBank.IndexOf(c) != 0)
                    {
                        y += 134;
                        x = 27;
                    }
                }

                x = 26;
                y = 20;

                foreach (Card c in p1Deck)
                {
                    Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                    if (c.holding == false)
                    {
                        c.r = new Rectangle(x, y, 84, 128);
                    }

                    e.Graphics.DrawImage(c.img, c.r);
                    e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                    x += 93;
                }
            }
            else
            {

                deckSizeLabel.Text = $"{p2Deck.Count}/15";

                e.Graphics.FillRectangle(red, currentDeck);
                int x = 27;
                int y = 197;

                foreach (Card c in p2CardBank)
                {
                    Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                    if (c.holding == false)
                    {
                        c.r = new Rectangle(x, y, 84, 128);
                    }

                    e.Graphics.DrawImage(c.img, c.r);
                    e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                    x += 93;

                    if (p2CardBank.IndexOf(c) % 9 == 0 && p2CardBank.IndexOf(c) != 0)
                    {
                        y += 134;
                        x = 27;
                    }
                }
                foreach (Card c in p2Deck)
                {
                    Font f = new Font(new FontFamily("Segoe Print"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
                    if (c.holding == false)
                    {
                        c.r = new Rectangle(x, y, 84, 128);
                    }

                    e.Graphics.DrawImage(c.img, c.r);
                    e.Graphics.DrawString($"{c.basePower}", f, new SolidBrush(Color.Yellow), c.r.X + 61, c.r.Y + 1);
                    x += 93;
                }
            }
        }



        private void DeckScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (turn == "P1")
            {
                foreach (Card c in p1CardBank)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                    }
                }
                foreach (Card c in p1Deck)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                    }
                }
            }
            else
            {
                foreach (Card c in p2CardBank)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                    }
                }
                foreach (Card c in p2Deck)
                {
                    if (c.r.IntersectsWith(mouse))
                    {
                        c.holding = true;
                    }
                }
            }
        }

        private void DeckScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (turn == "P1")
            {
                foreach (Card c in p1CardBank)
                {

                    if (c.holding)
                    {
                        c.holding = false;

                        if (mouse.IntersectsWith(currentDeck) && p1Deck.Count < 15)
                        {
                            AddCard(c, p1Deck, "P1");
                            p1CardBank.Remove(c);

                        }
                        break;
                    }

                }
                foreach (Card c in p1Deck)
                {

                    if (c.holding)
                    {
                        c.holding = false;

                        if (mouse.IntersectsWith(cardBankRec))
                        {
                            AddCard(c, p1CardBank, "P1");
                            p1Deck.Remove(c);

                        }
                        break;
                    }

                }
            }
            else
            {
                foreach (Card c in p2CardBank)
                {

                    if (c.holding)
                    {
                        c.holding = false;

                        if (mouse.IntersectsWith(currentDeck) && p2Deck.Count < 15)
                        {
                            AddCard(c, p2Deck, "P2");
                            p2CardBank.Remove(c);

                        }
                        break;
                    }

                }
                foreach (Card c in p2Deck)
                {

                    if (c.holding)
                    {
                        c.holding = false;

                        if (mouse.IntersectsWith(cardBankRec))
                        {
                            AddCard(c, p2CardBank, "P2");
                            p2Deck.Remove(c);

                        }
                        break;
                    }

                }
            }
        }

        public static void AddCard(Card c, List<Card> deck, string p)
        {
            deck.Add(new Card(c.basePower, c.rank, c.pawnTiles, c.effectTiles, c.img, c.effect, c.rarity));
            deck[deck.Count - 1].player = p;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (turn == "P1" && p1Deck.Count == 15)
            {
                turn = "P2";
            }
            else if (p2Deck.Count == 15)
            {
                Form1.ChangeScreen(this, new GameScreen());
            }
        }
    }
}
