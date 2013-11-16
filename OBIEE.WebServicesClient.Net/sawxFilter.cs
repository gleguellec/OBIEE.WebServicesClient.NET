//
//Author: Gael Le Guellec
//Date: 11-15-2013
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace OBIEE.WebServicesClient.Net
{
    public class sawxFilter : XmlDocument
    {
        public sawxFilter(string _type, string _operator, string _field, string _value): base()
        {
            XmlElement _root = this.CreateElement("sawx", "expr", "com.siebel.analytics.web/expression/v1.1");
            this.AppendChild(_root);
            this.DocumentElement.SetAttribute("xmlns:sawx", "com.siebel.analytics.web/expression/v1.1");
            this.DocumentElement.SetAttribute("xmlns:saw", "com.siebel.analytics.web/report/v1.1");
            this.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            this.DocumentElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            this.DocumentElement.SetAttribute("xmlVersion", "201201160");

            XmlAttribute _rootTypeAttribute = CreateAttribute("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance");
            _rootTypeAttribute.Value = "sawx:" + _type;
            XmlAttribute _operatorAttribute = CreateAttribute("op");
            _operatorAttribute.Value = _operator;
            _root.Attributes.Append(_rootTypeAttribute);
            _root.Attributes.Append(_operatorAttribute);

            XmlElement _fieldNode = this.CreateElement("sawx", "expr", "com.siebel.analytics.web/expression/v1.1");
            XmlAttribute _fieldTypeAttribute = CreateAttribute("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance");
            _fieldTypeAttribute.Value = "sawx:sqlExpression";
            _fieldNode.InnerText = _field;
            _fieldNode.Attributes.Append(_fieldTypeAttribute);

            XmlElement _valueNode = this.CreateElement("sawx", "expr", "com.siebel.analytics.web/expression/v1.1");
            XmlAttribute _valueTypeAttribute = CreateAttribute("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance");
            _valueTypeAttribute.Value = "xsd:string";
            _valueNode.InnerText = _value;
            _valueNode.Attributes.Append(_valueTypeAttribute);

            _root.AppendChild(_fieldNode);
            _root.AppendChild(_valueNode);
        }
    }
}
