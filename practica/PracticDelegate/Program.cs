using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace PracticDelegate
{
    class Program
    {
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            
            string json = client.DownloadString("https://swapi.co/api/people/1/");
            StarWarsPeople[] result = JsonConvert.DeserializeObject<StarWarsPeople[]>(json);

            Console.WriteLine(result[0].Name);
            result[0].Id = Int32.Parse(result[0].Url.Substring(28, 1));
            Console.WriteLine(result[0].Id);

            var serializerXml = new XmlSerializer(typeof(StarWarsPeople[]));
            using (var stream = File.Create("xmlPerson.xml"))
            {
                serializerXml.Serialize(stream, result);
            }
            

            /*XmlDocument xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement("people");

            

            var idElement = xmlDocument.CreateElement("id");
            idElement.InnerText = result.Id.ToString();
            var nameElement = xmlDocument.CreateElement("name");
            nameElement.InnerText = result.Name;
            var heightElement = xmlDocument.CreateElement("height");
            heightElement.InnerText = result.Height.ToString();
            var massElement = xmlDocument.CreateElement("mass");
            massElement.InnerText = result.Mass.ToString();
            var hairColorElement = xmlDocument.CreateElement("hairColor");
            hairColorElement.InnerText = result.Hair_Color;
            var skinColorElement = xmlDocument.CreateElement("skinColor");
            skinColorElement.InnerText = result.Skin_Color;
            var eyeColorElement = xmlDocument.CreateElement("eyeColor");
            eyeColorElement.InnerText = result.Eye_Color;
            var birthYearElement = xmlDocument.CreateElement("birthYear");
            birthYearElement.InnerText = result.Birth_Year;
            var genderElement = xmlDocument.CreateElement("gender");
            genderElement.InnerText = result.Gender;
            var homeworldElement = xmlDocument.CreateElement("homeworld");
            homeworldElement.InnerText = result.Homeworld;
            var createdElement = xmlDocument.CreateElement("created");
            createdElement.InnerText = result.Created;
            var editedElement = xmlDocument.CreateElement("edited");
            editedElement.InnerText = result.Edited;
            var urlElement = xmlDocument.CreateElement("url");
            urlElement.InnerText = result.Url;


            rootElement.AppendChild(idElement);
            rootElement.AppendChild(nameElement);
            rootElement.AppendChild(heightElement);
            rootElement.AppendChild(massElement);
            rootElement.AppendChild(hairColorElement);
            rootElement.AppendChild(skinColorElement);
            rootElement.AppendChild(eyeColorElement);
            rootElement.AppendChild(birthYearElement);
            rootElement.AppendChild(genderElement);
            rootElement.AppendChild(homeworldElement);
            rootElement.AppendChild(createdElement);
            rootElement.AppendChild(editedElement);
            rootElement.AppendChild(urlElement);


            xmlDocument.AppendChild(rootElement);

            xmlDocument.Save("people.xml");*/
        }
    }
}
