using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HtmlAgilityPack;

namespace Primer_parser
{
    public class Helper
    {
        public List<string> DigoTrue(string url)
        {
            // var htmlDoc = new HtmlAgilityPack.HtmlDocument {OptionFixNestedTags = true};

            // There are various options, set as needed

            // filePath is a path to a file containing the html
            //using (var fs = new FileStream("test.htm", FileMode.Create))
            //{
            //    using (var w = new StreamWriter(fs, Encoding.UTF8))
            //    {
            //        w.WriteLine("<body><H1>Hello</H1></body>");
            //    }
            //}

            using (var myWebClient = new WebClient())
            {
                myWebClient.Headers["User-Agent"] = "MOZILLA/5.0 (WINDOWS NT 6.1; WOW64) APPLEWEBKIT/537.1 (KHTML, LIKE GECKO) CHROME/21.0.1180.75 SAFARI/537.1";

                if (url != "")
                {
                    try
                    {
                        string page = myWebClient.DownloadString(url);

                        HtmlDocument doc = new HtmlDocument() { OptionUseIdAttribute = true };
                        doc.LoadHtml(page);

                        //var filePath = "test.htm";
                        //htmlDoc.Load(filePath);

                        // Use:  htmlDoc.LoadHtml(xmlString);  to load from a string (was htmlDoc.LoadXML(xmlString)

                        // ParseErrors is an ArrayList containing any errors from the Load statement
                        //if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
                        //{
                        //    Console.WriteLine("Errores!!!!");
                        //    // Handle any parse errors as required

                        //}
                        //else
                        {

                            if (doc.DocumentNode != null)
                            {
                                HtmlAgilityPack.HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//body");

                                if (bodyNode != null)
                                {
                                    List<string> hrefTags = new List<string>();
                                    //cambiar funcion aqui
                                    hrefTags = ExtractResultsFromDRF(doc);

                                    //return "El site si tiene bodyNode que es: " + bodyNode.FirstChild.Id;
                                    return hrefTags;
                                    // Do something with bodyNode
                                }
                            }
                        }

                    }
                    catch (Exception)
                    {
                        List<string> hrefTags1 = new List<string>();
                        return hrefTags1;
                    }

                }
                else
                {
                    List<string> hrefTags2 = new List<string>();
                    return hrefTags2;

                }
            }
            List<string> hrefTags3 = new List<string>();
            return hrefTags3;

        }


        private List<string> ExtractAllAHrefTags(HtmlDocument htmlSnippet)
        {
            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }

            return hrefTags;
        }

        private List<string> ExtractAllImgTags(HtmlDocument htmlSnippet)
        {
            List<string> imgTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//img"))
            {
                HtmlAttribute att = link.Attributes["src"];
                imgTags.Add(att.Value);
            }

            return imgTags;
        }

        private List<string> ExtractAllTables(HtmlDocument htmlSnippet)
        {
            List<string> tables = new List<string>();

            //foreach (HtmlNode table in htmlSnippet.DocumentNode.SelectNodes("//table"))
            //{
            //    try
            //    {
            //        HtmlAttribute att = table.Attributes["WIDTH"];
            //        if (att != null)
            //            tables.Add(att.Value);
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("errorrrrr!");
            //        throw;
            //    }

            //}

            //var perro = htmlSnippet.DocumentNode.SelectSingleNode("//html/body/div/div[2]/div[2]/div/div/div/table"); ///tbody/tr/td/center/font/a[2]/center/table/tbody/tr[3]/td[2]
            
            //    try
            //    {
            //        //HtmlAttribute att = table.Attributes["WIDTH"];
            //        //if (att != null)
            //        tables.Add(perro.InnerHtml);
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("errorrrrr!");
            //        throw;
            //    }

            


            //html/body/div/div[2]/div[2]/div/div/div/table/tbody/tr/td/center/font/a[2]/center/table/tbody/tr[3]/td[2]



            var perro = htmlSnippet.DocumentNode.SelectSingleNode("//html/body/div/div[2]/div[2]/div/div/div/table/tr/td/center"); ///tbody/tr/td/center/font/a[2]/center/table/tbody/tr[3]/td[2]
            var perritos = perro.Descendants("TD");
            foreach (var htmlNode in perritos)
            {
                tables.Add(htmlNode.InnerText);
            }
            var elPerrito  = perritos.ElementAt(4).InnerText;

            //try
            //{
            //    foreach (HtmlNode row in perro.SelectNodes("tr"))
            //    {
            //        foreach (HtmlNode cell in row.SelectNodes("th|td"))
            //        {
            //            foreach (var xxx in cell.Descendants())
            //            {
            //                tables.Add(xxx.OuterHtml);
                            
            //            }

            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("errorrrrr!");
            //    throw;
            //}
            
              

            return tables;
        }
       

        private List<string> ExtractResultsFromDRF(HtmlDocument htmlSnippet)
        {
            var tables = new List<string>();

            var perro = htmlSnippet.DocumentNode.SelectSingleNode("//html/body");
            var elPerro = perro.InnerText.ToString();
            var perritos = perro.Descendants("TD");
            foreach (var htmlNode in perritos)
            {
                tables.Add(htmlNode.InnerText);
            }
           // var elPerrito = perritos.ElementAt(142).InnerText;
            return tables;
        }



    }
}