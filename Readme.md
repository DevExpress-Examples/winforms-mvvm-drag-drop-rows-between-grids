<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128614831/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T338673)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Drag-and-drop data rows from one grid to another (MVVM)


This example is based on the following example: [WinForms Data Grid - Drag-and-drop data rows from one grid to another](https://github.com/DevExpress-Examples/winforms-drag-drop-rows-from-one-grid-to-another). The example demonstrates how to implement drag-and-drop functionality between two grid controls using [DevExpress WinForms MVVM framework](https://docs.devexpress.com/WindowsForms/113955/build-an-application/winforms-mvvm).

To implement drag and drop using the MVVM pattern, create a helper class (`DragAndDropHelper`) that implements corresponding events (`Drop`, `DeleteRecord`). The `EventToCommand` method passes event arguments to corresponding ViewModel commands.


## Files to Review

* [DragDropForm.cs](./CS/DragDropForm.cs) (VB: [DragDropForm.vb](./VB/DragDropForm.vb))
* [DragAndDropHelper.cs](./CS/DragDropHelper/DragAndDropHelper.cs) (VB: [DragAndDropHelper.vb](./VB/DragDropHelper/DragAndDropHelper.vb))
* [File.cs](./CS/Model/File.cs) (VB: [File.vb](./VB/Model/File.vb))
* [Repository.cs](./CS/Model/Repository.cs) (VB: [Repository.vb](./VB/Model/Repository.vb))
* [TestView.cs](./CS/View/TestView.cs) (VB: [TestView.vb](./VB/View/TestView.vb))
* [DragDropViewModel.cs](./CS/ViewModels/DragDropViewModel.cs) (VB: [DragDropViewModel.vb](./VB/ViewModels/DragDropViewModel.vb))


## See Also

* [WinForms MVVM](https://docs.devexpress.com/WindowsForms/113955/build-an-application/winforms-mvvm)
* [WinForms Data Grid - Drag-and-drop data rows from one grid to another](https://github.com/DevExpress-Examples/winforms-drag-drop-rows-from-one-grid-to-another)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-mvvm-drag-drop-rows-between-grids&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-mvvm-drag-drop-rows-between-grids&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
