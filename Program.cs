﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static int onderGrens;
    static int bovenGrens;
    static int blokVooraad;
    static int aantalSteunenDieTimWiltHebben;
    static long schijven;

    static string input;
    static string[] inputString;

    static int[] verkrijgbareSB;
    static int[] matenDieTimWiltHebben;

    static int j;

    static void Main()
    {
        KrijgVooraad();
        Steunen();

        schijven = 0;

        // bereken het aantal schijven die nodig zijn
        for (int i = 0; i < aantalSteunenDieTimWiltHebben; i++)
        {
            j = zoekBlok(i);
            long maat = matenDieTimWiltHebben[i];


            if (j < blokVooraad)
            {
                if (maat == verkrijgbareSB[j])
                    continue;
                else if (maat < verkrijgbareSB[0]) // maat is kleiner dan alles wat er in de catalogus staat
                    schijven += matenDieTimWiltHebben[i];
                else // zit tussen twee maten in
                    schijven += (maat - verkrijgbareSB[j - 1]);
            }
            else if (blokVooraad == 0)
            {
                schijven += matenDieTimWiltHebben[i];
            }
            else // groter dan wat er in de catalogus staat
                schijven += (maat - verkrijgbareSB[j - 1]);
           
        }

        Console.WriteLine(schijven);
        Console.ReadLine();
    }

    // krijg de aantal blokken op vooraad en de maten van elk blok
    static void KrijgVooraad()
    {
        input = Console.ReadLine();
        inputString = input.Split(' ');
        blokVooraad = Convert.ToInt32(inputString[0]);

        verkrijgbareSB = new int[blokVooraad];

        for (int i = 0; i < blokVooraad; i++)
        {
            input = Console.ReadLine();
            inputString = input.Split(' ');
            verkrijgbareSB[i] = Convert.ToInt32(inputString[0]);
        }
    }

    // krijg de hoevelheid steunen die tim moet timmeren en de maat van elke steun
    static void Steunen ()
    {
        input = Console.ReadLine();
        inputString = input.Split(' ');
        aantalSteunenDieTimWiltHebben = Convert.ToInt32(inputString[0]);

        matenDieTimWiltHebben = new int[aantalSteunenDieTimWiltHebben];

        for (int i = 0; i < aantalSteunenDieTimWiltHebben; i++)
        {
            input = Console.ReadLine();
            inputString = input.Split(' ');
            matenDieTimWiltHebben[i] = Convert.ToInt32(inputString[0]);;
        }
    }

    // zoek de index van een blok mbv binary search
    static int zoekBlok (int x)
    {
        onderGrens = -1;
        bovenGrens = blokVooraad;
        int m = 0;
        int maat = matenDieTimWiltHebben[x];

        while (onderGrens < bovenGrens - 1)
        {
            m = (onderGrens + bovenGrens) / 2;
            
            if (verkrijgbareSB[m] < maat)
                onderGrens = m;
            else
                bovenGrens = m;
        }

        return bovenGrens;       
     }    
}

