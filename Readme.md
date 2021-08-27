<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E945)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to Prevent PivotGrid from Getting Properties Values


<p>This example shows how to prevent the PivotGrid from accessing some properties in the datasource. By default, the PivotGrid fetches all data from the datasource and sometimes such behavior can be undesirable. To prevent the PivotGrid from accessing properties, you should create a datasource wrapper that implements the ITypedList and IList interfaces. In the ITypedList.GetItemProperties method implementation, you should provide a list of properties that the PivotGrid should access. The IList interfaces implementation is necessary to enable the PivotGrid to access data. This datasource wrapper may not contain actual data but fetch it from the underlying datasource. This will prevent unnecessary data duplication between multiple datasource wrappers.</p><p>In this example, we have introduced an enumerable ReportType which describes possible properties combinations. A ReportType object is passed to the DataSourceWrapper class constructor to specify the desired report. Based on the ReportType object value, the GetItemProperties method returns one set of the PropertyDescriptor objects or another set.</p>

<br/>


