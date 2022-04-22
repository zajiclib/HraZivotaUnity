using System;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hra : MonoBehaviour
{
    const int SIRKA = 80;
    const int VYSKA = 80;

    public Bunka[,] hraciDeska;

    public Hra()
    {
        //Random random = new Random();

        hraciDeska = new Bunka[SIRKA, VYSKA];
        for (int i = 0; i < hraciDeska.GetLength(0); i++)
        {
            for (int j = 0; j < hraciDeska.GetLength(1); j++)
            {
              //  int rnd = random.Next(2);
              //  bool zivost = (rnd == 0);
              //  hraciDeska[i, j] = new Bunka(zivost, i, j);
            }
        }
    }


    public int OkoliBunkyZive(Bunka bunka)
    {
        if (bunka == null) return -1;

        int celkovyPocet = 0;


        for (int i = bunka.PosX - 1; i < bunka.PosX + 1; i++)
        {
            for (int j = bunka.PosY - 1; j < bunka.PosY + 1; j++)
            {
                if (i == bunka.PosX && j == bunka.PosY)
                {
                    continue;
                }
                else
                {
                    try
                    {

                        Bunka sousedniBunka = hraciDeska[bunka.PosX + 1, bunka.PosY + 1];

                        if (sousedniBunka.JeZiva) celkovyPocet++;

                    }
                    catch (IndexOutOfRangeException e)
                    {
                        continue;
                    }
                }
            }
        }

        return celkovyPocet;
    }

    public void update()
    {
        for (int i = 0; i < this.hraciDeska.GetLength(0); i++)
        {
            for (int j = 0; j < this.hraciDeska.GetLength(1); j++)
            {
                Bunka bunka = this.hraciDeska[i, j];
                //Console.WriteLine("Bunka na souradnicich ma sousedu x: " + i + ", y:" + j + " " + hra.OkoliBunkyZive(bunka));
                int pocetSousedu = this.OkoliBunkyZive(bunka);
                bunka.aktivatorBunky(pocetSousedu);

            }
        }
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hraciDeska.GetLength(0); i++)
        {
            for (int j = 0; j < hraciDeska.GetLength(1); j++)
            {
                Bunka bunka = hraciDeska[i, j];

                if (bunka.JeZiva)
                {
                    sb.Append("X ");
                }
                else
                {
                    sb.Append("  ");
                }
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}