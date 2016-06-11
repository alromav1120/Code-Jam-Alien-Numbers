using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//                                                          //Author: Roman Alfaro Vaquez
//                                                          //Date: 22/04/2016
//                                                          //Proposal: Alien Number CodeJam
//                                                          //Especification: The decimal numeral system is composed of 
//                                                          //      ten digits, which we represent as "0123456789" 
//                                                          //      (the digits in a system are written from lowest 
//                                                          //      to highest). Imagine you have discovered an alien 
//                                                          //      numeral system composed of some number of digits, 
//                                                          //      which may or may not be the same as those used in 
//                                                          //      decimal. For example, if the alien numeral system 
//                                                          //      were represented as "oF8", then the numbers one 
//                                                          //      through ten would be (F, 8, Fo, FF, F8, 8o, 8F, 88, Foo, FoF).
//                                                          //      We would like to be able to work with numbers in 
//                                                          //      arbitrary alien systems. More generally, we want 
//                                                          //      to be able to convert an arbitrary number that's 
//                                                          //      written in one alien system into a second alien system. 

namespace AlienNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int intContadorLineas = 0;
            String strLinea;
            //                                              //Read File A-Small-Practice-in
            StreamReader streamArchivo = new StreamReader(@"C:\A-small-practice.in");

            //                                              //Read Line by line until finish the file
            /*WHILE-DO*/
            while(
                ((strLinea = streamArchivo.ReadLine()) != null)
                )
            {
                //                                          //Convertir de un numero alien a base 10
                int total = 0;
                if (
                    //                                      //Don't considere the first line because is the total of lines
                    //                                      //      in our file.
                    intContadorLineas != 0
                    )
                {
                    //                                      //Separamos la línea del archivo en 3:
                    //                                      //      La palabra la cual queremos convertir,
                    //                                      //      La base como viene dicha palabra y
                    //                                      //      La base a la cual se requiere convertir.
                    String[] arrPalabra = strLinea.Split(' ');

                    String alien_number = arrPalabra[0];
                    String source_language = arrPalabra[1];
                    String target_language = arrPalabra[2];

                    //                                      //Tomamos la longitud de la base incial de la palabra 
                    //                                      //      a convertir.
                    int Base = Convert.ToInt32(source_language.Length);

                    int exp = 0;

                    for (int i = alien_number.Length - 1; i > -1; i = i - 1)
                    {
                        //                                  //Buscamos la posicón de la letra de la palabra a convertir
                        //                                  //      en la posición de la base de esa misma palabra.
                        int posicion = source_language.IndexOf(alien_number[i]);
                        
                        //                                  //Convertimos dichos caracteres en su valor en cualquier tipo de
                        //                                  //      base a la cual se quiera convertir.
                        int valor_digito =(int)(posicion *( Math.Pow(Base,exp)));
                        total = total + valor_digito;
                        exp = exp + 1;
                    }

                    //                                          //Convertir de base 10 a la base deseada.
                    //                                          //Base a la cual se requiere convertir la palabra.
                    int Baseaconvertir = target_language.Length;
                    String strPalabraSalida = "";

                    while(
                        //                                      //Comparamos que si el valor calculado no ha sido menor
                        total > 0
                        )
                    {
                        //                                      //Comenzamos a hacer divisiones dependiendo de la
                        //                                      //      base.
                        int residuo = total % Baseaconvertir;
                        total = total - residuo;
                        total = total / Baseaconvertir;
                        //                                      //Buscamos del numero decimal en la posición de la palabra
                        //                                      //      a la base que queremos convertir para concatenarla.
                        char charCaracter_convertir = target_language[residuo];
                        strPalabraSalida = charCaracter_convertir + strPalabraSalida;
                    }

                    Console.WriteLine("Case # " + intContadorLineas + ": " + strPalabraSalida);

                }

                intContadorLineas = intContadorLineas + 1;

            }

            streamArchivo.Close();
            Console.ReadKey();
        }
    }
}
