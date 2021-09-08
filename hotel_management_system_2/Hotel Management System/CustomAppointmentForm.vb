#Region "Note"
'
'{**************************************************************************************************************}
'{  This file is automatically created when you open the Scheduler Control smart tag                            }
'{  *and click Create Customizable Appointment Dialog.                                                          }
'{  It contains a a descendant of the default appointment editing form created by visual inheritance.           }
'{  In Visual Studio Designer add an editor that is required to edit your appointment custom field.             }
'{  Modify the LoadFormData method to get data from a custom field and fill your editor with data.              }
'{  Modify the SaveFormData method to retrieve data from the editor and set the appointment custom field value. }
'{  The code that displays this form is automatically inserted                                                  }
'{  *in the EditAppointmentFormShowing event handler of the SchedulerControl.                                   }
'{                                                                                                              }
'{**************************************************************************************************************}
'
#End Region ' Note

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Partial Public Class CustomAppointmentForm
    Inherits DevExpress.XtraScheduler.UI.AppointmentForm
	Public Sub New()
		InitializeComponent()
	End Sub
    Public Sub New(ByVal control As DevExpress.XtraScheduler.SchedulerControl, ByVal apt As DevExpress.XtraScheduler.Appointment)
        MyBase.New(control, apt)
        InitializeComponent()
    End Sub
    Public Sub New(ByVal control As DevExpress.XtraScheduler.SchedulerControl, ByVal apt As DevExpress.XtraScheduler.Appointment, ByVal openRecurrenceForm As Boolean)
        MyBase.New(control, apt, openRecurrenceForm)
        InitializeComponent()
    End Sub
	''' <summary>
	''' Add your code to obtain a custom field value and fill the editor with data.
	''' </summary>
    Public Overrides Sub LoadFormData(ByVal appointment As DevExpress.XtraScheduler.Appointment)
        MyBase.LoadFormData(appointment)
    End Sub
	''' <summary>
	''' Add your code to retrieve a value from the editor and set the custom appointment field.
	''' </summary>
    Public Overrides Function SaveFormData(ByVal appointment As DevExpress.XtraScheduler.Appointment) As Boolean
        Return MyBase.SaveFormData(appointment)
    End Function
    '' <summary>
    ''' Add your code to notify that any custom field is changed. Return true if a custom field is changed, otherwise false.
    ''' </summary>
    Public Overrides Function IsAppointmentChanged(ByVal appointment As DevExpress.XtraScheduler.Appointment) As Boolean
        Return False
    End Function
End Class
