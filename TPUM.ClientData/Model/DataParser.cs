using System;
using System.Collections.Generic;
using System.Text;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData.Model
{
    public static class DataParser
    {
        public static SClient ParseSClient(string message)
        {
            int w = 0;
            string getId, getName, getLName, getAge, sign;
            getId = getName = getLName = getAge = sign = "";

            foreach (char c in message)
            {
                if (c != ':')
                {
                    sign += c;
                }
                else
                {
                    w++;

                    if (w == 1)
                    {
                        getId = sign;
                    }
                    else if (w == 2)
                    {
                        getName = sign;
                    }
                    else if (w == 3)
                    {
                        getLName = sign;
                    }

                    sign = "";
                }
            }
            getAge = sign;

            SClient sclient = new SClient();
            sclient.Id = int.Parse(getId);
            sclient.Name = getName;
            sclient.LastName = getLName;
            sclient.Age = int.Parse(getAge);
            sclient.Cart = new SCart { Products = new List<SProduct>() };

            return sclient;
        }


        public static SProduct ParseSProduct(string message)
        {
            int w = 0;
            string getId, getName, getAuthor, getPrice, getDate, sign;
            getId = getName = getAuthor = getPrice = getDate = sign = "";

            foreach (char c in message)
            {
                if (c != ':')
                {
                    sign += c;
                }
                else
                {
                    w++;

                    if (w == 1)
                    {
                        getId = sign;
                    }
                    else if (w == 2)
                    {
                        getName = sign;
                    }
                    else if (w == 3)
                    {
                        getAuthor = sign;
                    }
                    else if (w == 4)
                    {
                        getPrice = sign;
                    }

                    sign = "";
                }
            }
            getDate = sign;


            SProduct sproduct = new SProduct();
            sproduct.Id = int.Parse(getId);
            sproduct.Name = getName;
            sproduct.Author = getAuthor;
            sproduct.Price = float.Parse(getPrice);
            sproduct.MinimalAge = int.Parse(getDate);

            return sproduct;
        }
    }
}
