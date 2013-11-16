The sawxFilter class an XML document that represent a prompted filter. It is added to the filterExpressions string array of the ReportParams object that will be passed to the executeXMLQuery() function of the XmlViewServiceSoapClient instance.

Example:

ReportParams _reportParams = new ReportParams();
XmlViewServiceSoapClient _xmlViewService = new XmlViewServiceSoapClient();
XMLQueryExecutionOptions _xmlQueryOptions = new XMLQueryExecutionOptions();
_xmlQueryOptions.maxRowsPerPage = 100;
_xmlQueryOptions.refresh = true;
_xmlQueryOptions.presentationInfo = true;
QueryResults _queryResults = new QueryResults();

sawxFilter _userFilter = new sawxFilter("logical", "LIKE", "\"Dim-FND User\".\"User Name\"", "ABCDEF");
_reportParams.filterExpressions = new string[] {_userFilter.OuterXml};
_queryResults = _xmlViewService.executeXMLQuery(_reportRef, XMLQueryOutputFormat.SAWRowsetData, _xmlQueryOptions, _reportParams, Session["sawsoap:sessionID"].ToString());

/* 
_userFilter.OuterXml =
<sawx:expr 
xmlns:sawx="com.siebel.analytics.web/expression/v1.1" 
xmlns:saw="com.siebel.analytics.web/report/v1.1" 
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
xmlns:xsd="http://www.w3.org/2001/XMLSchema" 
xmlVersion="201201160" 
xsi:type="sawx:logical" op="LIKE">
  <sawx:expr xsi:type="sawx:sqlExpression">"Dim-FND User"."User Name"</sawx:expr>
  <sawx:expr xsi:type="xsd:string">"ABCDEF"</sawx:expr>
</sawx:expr>
*/
