using System;
using System.Xml;

namespace Task14_2
{
    class Program
    {
        static void Main()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach(XmlNode xNode in xRoot)
            { 
                Console.WriteLine($"Элемент первого уровня: {xNode.Name}, кол-во дочерних элементов {xNode.ChildNodes.Count}");
                foreach(XmlNode childNode in xNode.ChildNodes)
                {
                    Console.WriteLine($"\tДочерний элемент: {childNode.Name}, кол-во потомков {DescendantsCount(childNode)}");
                }
                if (!xNode.HasChildNodes)
                {
                    Console.WriteLine($"\tДочерний элемент: no child, кол-во потомков 1");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static int DescendantsCount(XmlNode childNode)
        {
            foreach(XmlNode node in childNode.ChildNodes)
            {
                if (node.HasChildNodes)
                {
                    return node.ChildNodes.Count + DescendantsCount(node);
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
