<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128614831/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T338673)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DragDropForm.cs](./CS/DragDropForm.cs) (VB: [DragDropForm.vb](./VB/DragDropForm.vb))
* [DragAndDropHelper.cs](./CS/DragDropHelper/DragAndDropHelper.cs) (VB: [DragAndDropHelper.vb](./VB/DragDropHelper/DragAndDropHelper.vb))
* [File.cs](./CS/Model/File.cs) (VB: [File.vb](./VB/Model/File.vb))
* [Repository.cs](./CS/Model/Repository.cs) (VB: [Repository.vb](./VB/Model/Repository.vb))
* [TestView.cs](./CS/View/TestView.cs) (VB: [TestView.vb](./VB/View/TestView.vb))
* [DragDropViewModel.cs](./CS/ViewModels/DragDropViewModel.cs) (VB: [DragDropViewModel.vb](./VB/ViewModels/DragDropViewModel.vb))
<!-- default file list end -->
# How to implement drag-and-drop between two Grids using MVVM


<p>This example is the modified  <a href="https://www.devexpress.com/Support/Center/p/E694">Drag-and-drop data rows from one grid to another</a> example. It demonstrates how to implement drag-and-drop functionality between two Grids using our MVVM framework. To implement drag and drop using the MVVM pattern, create a helper class (<strong>DragAndDropHelper </strong>class) that implements corresponding events (the "<strong>Drop</strong>" and "<strong>DeleteRecord</strong>" events) in a similar manner it is implemented in WPF. Arguments of these events are passed to corresponding ViewModel commands using the <strong>EventToCommand</strong> method.</p>

<br/>


