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


