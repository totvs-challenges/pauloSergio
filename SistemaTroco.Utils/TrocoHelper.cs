using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTroco.Utils
{
    public static class TrocoHelper
    {
        public static Resultado calculaTroco(double valor, double pago)
        {
            int Nota100 = 0;
            int Nota50 = 0;
            int Nota20 = 0;
            int Nota10 = 0;


            int Cent50 = 0;
            int Cent10 = 0;
            int Cent5 = 0;
            int Cent1 = 0;


            string result = "";
            double troco;

            int vlr;
            bool temNota = true;
            bool temCent = true;
            troco = (pago - valor);


            //  Definindo as notas do troco
            vlr = ((int)(troco));

            while ((vlr != 0) && (temNota))
            {
                temNota = false;
                while (vlr >= 100)
                {
                    vlr = vlr - 100;
                    Nota100++;
                    temNota = true;
                }
                while (vlr >= 50)
                {
                    vlr = vlr - 50;
                    Nota50++;
                    temNota = true;
                }
                while (vlr >= 20)
                {
                    vlr = vlr - 20;
                    Nota20++;
                    temNota = true;
                }
                while (vlr >= 10)
                {
                    vlr = vlr - 10;
                    Nota10++;
                    temNota = true;
                }
            }

            //  Definindo os centavos do troco
            vlr = ((int)(Math.Round(((vlr + (troco - ((int)(troco))))
                              * 100))));

            while ((vlr != 0) && (temCent))
            {
                temCent = false;
                while (vlr >= 50)
                {
                    vlr = vlr - 50;
                    Cent50++;
                    temCent = true;
                }

                while (vlr >= 10)
                {
                    vlr = vlr - 10;
                    Cent10++;
                    temCent = true;
                }

                while (vlr >= 5)
                {
                    vlr = vlr - 5;
                    Cent5++;
                    temCent = true;
                }

                while (vlr >= 1)
                {
                    vlr = vlr - 1;
                    Cent1++;
                    temCent = true;
                }
            }

            //Notas
            if (Nota100 > 0)
            {
                result = result + Nota100 + " notas de R$ 100 \n";
            }

            if (Nota50 > 0)
            {
                result = result + Nota50 + " notas de R$ 50 \n";
            }

            if (Nota20 > 0)
            {
                result = result + Nota20 + " notas de R$ 20 \n";
            }

            if (Nota10 > 0)
            {
                result = result + Nota10 + " notas de R$ 10 \n";
            }

            if (Cent50 > 0)
            {
                result = result + Cent50 + " moeda(s) de R$ 50 centavos \n";
            }

            if (Cent10 > 0)
            {
                result = result + Cent10 + "  moeda(s) de  R$ 10 centavos\n";
            }

            if (Cent5 > 0)
            {
                result = result + Cent5 + "  moeda(s) de R$ 5 centavos\n";
            }

            if (Cent1 > 0)
            {
                result = result + Cent1 + "  moeda(s) de R$ 1 centavo\n";
            }

            Resultado listTroco = new Resultado()
            {
                Troco = troco.ToString(),
                Descricao = result
            };

            return listTroco;
        }
    }
}
