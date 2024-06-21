using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens_Blood_Rip_Off
{
    public class Card
    {
        public bool holding = false;
        public bool effectTriggered = false;
        public int power, basePower, rank, boostNumberD;
        public Image img;
        public Rectangle r;
        public List<Point> pawnTiles = new List<Point>();
        public List<Point> effectTiles = new List<Point>();
        public string effect, player, rarity;
        public Card(int basePower, int rank, List<Point> pawnTiles, List<Point> effectTiles, Image img, string effect, string rarity)
        {
            this.basePower = basePower;
            this.rank = rank;

            foreach (Point p in pawnTiles)
            {
                this.pawnTiles.Add(p);
            }

            foreach (Point p in effectTiles)
            {
                this.effectTiles.Add(p);
            }
            this.img = img;
            this.effect = effect;
            this.rarity = rarity;

        }

        public void Effect()
        {
            power = basePower;

            switch (effect)
            {
                case "BoostUp":
                    if (basePower == 1)
                    {
                        if (player == "P1")
                        {
                            power += GameScreen.boostUNum1;
                        }
                        else
                        {
                            power += GameScreen.boostUNum2;
                        }
                    }
                    else
                    {
                        if (player == "P1")
                        {
                            power += GameScreen.boostUNum1 * 2;
                        }
                        else
                        {
                            power += GameScreen.boostUNum2 * 2;
                        }
                    }
                    break;
                case "BoostDown":
                    if (player == "P1")
                    {
                        power += (GameScreen.boostDNum1 - boostNumberD) * 2;
                    }
                    else
                    {
                        power += (GameScreen.boostDNum2 - boostNumberD) * 2;
                    }
                    break;
            }
        }

        public void Move(int x, int y)
        {
            if (holding)
            {
                r.X = x;
                r.Y = y;
            }
        }
    }
}
