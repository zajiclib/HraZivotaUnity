using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunka : MonoBehaviour
{
    private bool _jeZiva;
    private int _posY;
    private int _posX;

    public Bunka(bool jeZiva, int posY, int posX)
    {
        this._jeZiva = jeZiva;
        this._posY = posY;
        this._posX = posX;
    }

    public bool JeZiva
    {
        get => _jeZiva;
        set
        {
            _jeZiva = value;
        }
    }

    public int PosY
    {
        get => _posY;
        set
        {
            _posY = value;
        }
    }

    public int PosX
    {
        get => _posX;
        set
        {
            _posX = value;
        }
    }

    public void aktivatorBunky(int pocetZivychBunekVOkoli)
    {
        if (this.JeZiva)
        {
            if (pocetZivychBunekVOkoli < 2 || pocetZivychBunekVOkoli > 3)
            {
                this.JeZiva = false;
            }
        }

        else
        {
            if (pocetZivychBunekVOkoli == 3)
            {
                this.JeZiva = true;
            }
        }


    }
}
