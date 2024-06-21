using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Queens_Blood_Rip_Off
{
    public class Tiles
    {

        public int pawns, power;
        public int effect = 0;
        public string player;
        public Rectangle r;
        public Card c;

        public Tiles(int pawns, string player, Rectangle r)
        {
            this.pawns = pawns;
            this.player = player;
            this.r = r;
        }

        public void play()
        {

            if (c.effect == "AddCardU")
            {
                if (c.player == "P1")
                {
                    GameScreen.AddCard(Form1.MaM, GameScreen.p1Hand, "P1");
                    GameScreen.p1Hand[GameScreen.p1Hand.Count - 1].r = new Rectangle(r.X + 20, r.Y + 40, 84, 128);

                }
                else
                {
                    GameScreen.AddCard(Form1.MaM, GameScreen.p2Hand, "P2");
                    GameScreen.p2Hand[GameScreen.p2Hand.Count - 1].r = new Rectangle(r.X + 20, r.Y + 40, 84, 128);
                }
            }

            if (c.effect == "BoostDown")
            {
                if (player == "P1")
                {
                    c.boostNumberD = GameScreen.boostDNum1;
                }
                else
                {
                    c.boostNumberD = GameScreen.boostDNum2;
                }
            }

            foreach (Point p in c.pawnTiles)
            {

                Rectangle rec;

                if (player == "P1")
                {
                    rec = new Rectangle(r.X + (r.Width * p.X + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }
                else
                {
                    rec = new Rectangle(r.X + (r.Width * (p.X * -1) + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }

                foreach (Tiles t in GameScreen.tile)
                {
                    if (rec.IntersectsWith(t.r) && t.c == null)
                    {
                        t.pawns++;

                        if (t.pawns > 3)
                        {
                            t.pawns = 3;
                        }
                        t.player = player;
                    }
                }
            }

            foreach (Point p in c.effectTiles)
            {
                Rectangle rec;

                if (player == "P1")
                {
                    rec = new Rectangle(r.X + (r.Width * p.X + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }
                else
                {
                    rec = new Rectangle(r.X + (r.Width * (p.X * -1) + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }

                foreach (Tiles t in GameScreen.tile)
                {
                    if (rec.IntersectsWith(t.r))
                    {
                        if (c.effect == "UP")
                        {
                            t.effect += 1;
                        }
                        else if (c.effect == "Down")
                        {
                            t.effect -= 1;
                        }
                    }
                }
            }
        }

        public void Destroy()
        {
           
            pawns = 1;


            
            if(c.effect == "AddCardD")
            {
                if (c.player == "P1")
                {
                    GameScreen.AddCard(Form1.HSM, GameScreen.p1Hand, "P1");
                    GameScreen.p1Hand[GameScreen.p1Hand.Count - 1].r = new Rectangle(r.X + 20, r.Y + 40, 84, 128);
                    
                }
                else
                {
                    GameScreen.AddCard(Form1.HSM, GameScreen.p2Hand, "P2");
                    GameScreen.p2Hand[GameScreen.p2Hand.Count - 1].r = new Rectangle(r.X + 20, r.Y + 40, 84, 128);
                }
            }

            if (c.effect == "DeathBoost")
            {
                foreach (Point p in c.effectTiles)
                {
                    Rectangle rec;

                    if (player == "P1")
                    {
                        rec = new Rectangle(r.X + (r.Width * p.X + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                    }
                    else
                    {
                        rec = new Rectangle(r.X + (r.Width * (p.X * -1) + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                    }

                    foreach (Tiles t in GameScreen.tile)
                    {
                        if (rec.IntersectsWith(t.r))
                        {
                            if (t.c != null)
                            {
                                t.c.basePower += 2;
                            }
                        }
                    }
                }
            }

            if (player == "P1")
            {
                if (effect > 0)
                {
                    GameScreen.boostUNum1 -= 1;
                }
                GameScreen.boostDNum1 += 1;
            }
            else
            {
                if (effect > 0)
                {
                    GameScreen.boostUNum2 -= 1;
                }
                GameScreen.boostDNum2 += 1;
            }

            foreach (Point p in c.effectTiles)
            {
                Rectangle rec;

                if (player == "P1")
                {
                    rec = new Rectangle(r.X + (r.Width * p.X + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }
                else
                {
                    rec = new Rectangle(r.X + (r.Width * (p.X * -1) + 10), r.Y + (r.Height * p.Y + 10), 10, 10);
                }

                foreach (Tiles t in GameScreen.tile)
                {
                    if (rec.IntersectsWith(t.r))
                    {
                        if (c.effect == "UP" && t.effect > 0)
                        {
                            t.effect -= 1;
                        }
                        else if (c.effect == "Down" && t.effect < 0)
                        {
                            t.effect += 1;
                        }
                    }
                }
            }

            c = null;
        }


       
    }
}
