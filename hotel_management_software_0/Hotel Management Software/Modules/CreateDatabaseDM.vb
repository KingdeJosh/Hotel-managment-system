Imports System.IO
Imports System.Data.SqlClient

Module CreateDatabaseDM



    Public Function CreateNewCompany(Optional ByVal IsEmptyDatabase As Boolean = False, Optional ByVal IsHostingSqlServer As Boolean = False) As Boolean
        Dim iscreateD As Boolean = False
        Dim ext As Integer = 0
        Dim extnewcmp As String = ""



        Try
            If IsHostingSqlServer = False Then
                extnewcmp = NewCompanyDBName
                Dim I As Integer
                For I = 100 To 4000
                    NewCompanyDBName = extnewcmp & I.ToString
                    If TestSQLDatabaseIsEXIST(NewCompanyDBName) = False Then
                        ext = I
                        Exit For
                    End If
                Next
                If I >= 4000 Then
                    MsgBox("The Maximum No of Companies reaches ,Please consult Developer ")
                    End
                End If
            End If


            MainSqlConn.ConnectionString = ConnectionStringFromFile
            MainSqlConn.Open()
            Try
                If IsHostingSqlServer = False Then
                    Dim SqlInsert As String = ""
letdoagain:
                    Try

                        SQLFcmd.Connection = MainSqlConn
                        SQLFcmd.CommandText = "CREATE DATABASE " & NewCompanyDBName
                        SQLFcmd.CommandType = CommandType.Text
                        SQLFcmd.ExecuteNonQuery()


                        'SQLFcmd.CommandText = "ALTER DATABASE " & NewCompanyDBName & " SET COMPATIBILITY_LEVEL = 100"
                        'SQLFcmd.CommandType = CommandType.Text
                        'SQLFcmd.ExecuteNonQuery()



                    Catch ex As Exception

                        NewCompanyDBName = extnewcmp & (ext + 1).ToString
                        ext = ext + 1
                        GoTo letdoagain
                    End Try
                End If
                'CREATE A DATABASE AS NAME new company database


                SQLFcmd.CommandText = "USE  " & NewCompanyDBName
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'CREATE A TABLE IN JVSKCOMPANY DATABASE
                SQLFcmd.CommandText = "CREATE TABLE [AccountGroups](	[GroupName] [nvarchar](75) NULL,	[GroupNameTemp] [nvarchar](75) NULL,	[GroupRoot] [nvarchar](75) NULL,	[GroupLevel] [int] NULL,	[UserName] [nvarchar](70) NULL,	[Isprimary] [smallint] NULL,	[AcType] [smallint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [images] (	[ImageData] [image] NULL,	[Bcode] [nvarchar](80) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Currencies]([CurrencyName] [nvarchar](250) NULL,[CurrencyCode] [nvarchar](8) NULL,[CurrencySymbol] [nvarchar](8) NULL,[IsActive] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [stockserialnos]([StockCode] [nvarchar](75) NULL,[StockSize] [nvarchar](25) NULL,[SerialNumber] [nvarchar](50) NULL,[MFD] [datetime] NULL,[Narration] [nvarchar](150) NULL,[Status] [nvarchar](10) NULL,[transcode] [bigint] NULL,[vouchername] [nvarchar](5) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [serialnumbermaster]([STOCKCODE] [nvarchar](75) NULL,[STOCKSIZE] [nvarchar](75) NULL,[SERIALNUMBER] [nvarchar](50) NULL,[Note1] [nvarchar](150) NULL,[Note2] [nvarchar](150) NULL,[Status] [int] NULL,[MFD] [datetime] NULL,[purchasedate] [datetime] NULL,[expirydate] [datetime] NULL,[warrantydate] [datetime] NULL,[Guaranteedate] [datetime] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                '
                SQLFcmd.CommandText = "CREATE TABLE [chequePrintFieldLabels]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[DBField] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[lalign] [nvarchar](150) NULL,[sample] [nvarchar](150) NULL,[DBType] [smallint] NULL,[FieldType] [smallint] NULL,[PrintText] [nvarchar](150) NULL,[FormatType] [int] NULL,[DatabaseValue] [int] NULL,[IsLedgerValue] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [SMSSettings]([username] [nvarchar](100) NULL,[password] [nvarchar](100) NULL,[PortName] [nvarchar](50) NULL,[BaudRate] [int] NULL,[SMSType] [nvarchar](50) NULL,[serviceno] [nvarchar](50) NULL,[IsDefault] [bit] NULL,[portno] [nvarchar](10) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [barcodesettings]([barcodelength] [int] NULL,[Isreplacezeros] [bit] NULL,[Isautofill] [bit] NULL,[FixedLength] [bit] NULL,[BarcodeType] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [notes]( [noteno] [bigint] NULL,[notes] [nvarchar](max) NULL,[notedate] [datetime] NULL,[UserID] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintingSchemes]([SchemeName] [nvarchar](50) NULL,[VoucherName] [nvarchar](50) NULL,[IsActive] [float] NULL,[ID] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintingSettings] ([PrinterName] [nvarchar](150) NULL,[schemename] [nvarchar](50) NULL,[Width] [int] NULL,[Height] [int] NULL,[IsLandScape] [bit] NULL,[fleft] [int] NULL,[fright] [int] NULL,[ftop] [int] NULL,[fbuttom] [int] NULL,[multi] [bit] NULL,[showsubtotals] [bit] NULL,[IsActive] [bit] NULL,[PaperName] [nvarchar](50) NULL,[LeftLogoIsOn] [bit] NULL,[RightLogoIson] [bit] NULL,[Leftlogoleft] [int] NULL,[Leftlogotop] [int] NULL,[Leftlogowidth] [int] NULL,[Leftlogoheight] [int] NULL,[Rightlogoleft] [int] NULL,[Rightlogotop] [int] NULL,[Rightlogowidth] [int] NULL,[Rightlogoheight] [int] NULL,[leftlogopath] [nvarchar](255) NULL,[rightlogopath] [nvarchar](255) NULL,[MaxRowsPerPage] [int] NULL,[RowHeight] [int] NULL,[showpageno] [bit] NULL,[pagenotop] [int] NULL,[pagenoleft] [int] NULL,[pageformat] [smallint] NULL,[Watermark] [nvarchar](250) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintLables]([schemename] [nvarchar](50) NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[labletext] [nvarchar](75) NULL,[isvisible] [bit] NULL,[align] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintLines]( [schemename] [nvarchar](50) NULL,[ftop] [real] NULL,[fleft] [real] NULL,[width] [real] NULL,[height] [real] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [real] NULL,[IsVisible] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [empsalaryincrements]([EmpName] [nvarchar](75) NULL,[oldSalary] [float] NULL,[NewSalary] [float] NULL,[Increment] [float] NULL,[Datefrom] [datetime] NULL,[datefromvalue] [bigint] NULL,[transcode] [bigint] NULL,[sno] [bigint] NULL,[Vhno] [nvarchar](50) NULL,[Transdate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[EMPID] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CompanyLeaves]([LeaveName] [nvarchar](50) NULL,[FromDate] [datetime] NULL,[ToDate] [datetime] NULL,[FromDateValue] [bigint] NULL,[ToDateValue] [bigint] NULL,[Narration] [nvarchar](150) NULL,[F1] [nvarchar](50) NULL,[N1] [float] NULL,[Sno] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PayTypes]([PayType] [nvarchar](20) NULL,[PayName] [nvarchar](75) NULL,[per] [float] NULL,[method] [nvarchar](15) NULL,[orderno] [int] NULL,[LedgerName] [nvarchar](75) NULL,[PaymentLedger] [nvarchar](75) NULL,[PayTypeGroup] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollvoucherLedgers]([PAYNAME] [nvarchar](75) NULL,[ledgername] [nvarchar](75) NULL,[Transcode] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollVoucherMasterData]([transcode] [bigint] NULL,[Transdate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[VoucherNo] [nvarchar](50) NULL,[VoucherRef] [nvarchar](50) NULL,[PayDate] [datetime] NULL,[PayDateValue] [bigint] NULL,[NetTotal] [float] NULL,[CashTotal] [float] NULL,[BankTotal] [float] NULL,[paymethod] [nvarchar](75) NULL,[narration] [nvarchar](250) NULL,[sqlstr] [nvarchar](550) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [PayRollVoucherPayMaster]([transcode] [bigint] NULL,[LedgerName] [nvarchar](75) NULL,[Amount] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [chequeinfo]([transcode] [bigint] NULL,[Ledgername] [nvarchar](75) NULL,[chequeno] [nvarchar](50) NULL,[chequedate] [datetime] NULL,[issuedate] [datetime] NULL,[details] [nvarchar](75) NULL,[vouchername] [nvarchar](50) NULL,[voucherno] [nvarchar](50) NULL,[amount] [float] NULL,[Isprinted] [bit] NULL,[chequedatevalue] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollvoucherRowDetails]([transcode] [bigint] NULL,[EmpName] [nvarchar](75) NULL,[PayName] [nvarchar](75) NULL,[OrderNo] [int] NULL,[amount] [float] NULL,[EmpID] [nvarchar](75) NULL,[Type] [int] NULL,[AttendenceDetails] [nvarchar](150) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [InvoiceDisplaySettings]([ShowTax] [bit] NULL,[ShowNetRate] [bit] NULL,[ShowItemName] [bit] NULL,[ShowItemCode] [bit] NULL,[ShowItemMoreInfo] [bit] NULL,[ShowDiscount] [bit] NULL,[ShowAccount] [bit] NULL,[ShowRatePer] [bit] NULL,[ShowNarration] [bit] NULL,[ShowCurrentBalance] [bit] NULL,[isallowdisc2] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [PrintAccounts]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[ObjectType] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[Lcase] [nvarchar](50) NULL,[Rcase] [nvarchar](50) NULL,[lalign] [nvarchar](50) NULL,[space] [int] NULL,[DBType] [smallint] NULL,[DBField] [nvarchar](50) NULL,[FormatType] [nvarchar](10) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE  [couponmaster]( [Cname] [nvarchar](50) NULL,[cper] [float] NULL,[datefrom] [datetime] NULL,[dateto] [datetime] NULL,[MaxValues] [float] NULL,[UsedValue] [float] NULL,[MaxNoofUses] [float] NULL,[isActive] [bit] NULL,[Datefromvalue] [bigint] NULL,[DatetoValue] [bigint] NULL,[IsAllowOneTime] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [PrintFieldLabels]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[DBField] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[lalign] [nvarchar](150) NULL,[sample] [nvarchar](150) NULL,[DBType] [smallint] NULL,[FieldType] [smallint] NULL,[PrintText] [nvarchar](150) NULL,[FormatType] [int] NULL,[DatabaseValue] [int] NULL,[IsLedgerValue] [int] NULL,[decimals] [int] NULL,[supress] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintHeadings] ([schemename] [nvarchar](50) NULL,[fTop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[Align] [nvarchar](50) NULL,[fcase] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[HeadText] [nvarchar](150) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [PrintingSchemes]([SchemeName] [nvarchar](50) NULL,[VoucherName] [nvarchar](50) NULL,[IsActive] [float] NULL,[ID] [int] NULL,[SchemeType] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PrintingSettings] ([PrinterName] [nvarchar](150) NULL,[schemename] [nvarchar](50) NULL,[Width] [int] NULL,[Height] [int] NULL,[IsLandScape] [bit] NULL,[fleft] [int] NULL,[fright] [int] NULL,[ftop] [int] NULL,[fbuttom] [int] NULL,[multi] [bit] NULL,[showsubtotals] [bit] NULL,[IsActive] [bit] NULL,[PaperName] [nvarchar](50) NULL,[LeftLogoIsOn] [bit] NULL,[RightLogoIson] [bit] NULL,[Leftlogoleft] [int] NULL,[Leftlogotop] [int] NULL,[Leftlogowidth] [int] NULL,[Leftlogoheight] [int] NULL,[Rightlogoleft] [int] NULL,[Rightlogotop] [int] NULL,[Rightlogowidth] [int] NULL,[Rightlogoheight] [int] NULL,[leftlogopath] [nvarchar](255) NULL,[rightlogopath] [nvarchar](255) NULL,[MaxRowsPerPage] [int] NULL,[RowHeight] [int] NULL,[showpageno] [bit] NULL,[pagenotop] [int] NULL,[pagenoleft] [int] NULL,[pageformat] [smallint] NULL,[IsrollPaper] [bit] NULL,[Isheaderfooterrepeat] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintLables] ([schemename] [nvarchar](50) NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[labletext] [nvarchar](255) NULL,[isvisible] [bit] NULL,[align] [nvarchar](50) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintLines]([schemename] [nvarchar](50) NULL,[ftop] [real] NULL,[fleft] [real] NULL,[width] [real] NULL,[height] [real] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [real] NULL,[IsVisible] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PrintRecords]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[ObjectType] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[Lcase] [nvarchar](50) NULL,[Rcase] [nvarchar](50) NULL,[lalign] [nvarchar](50) NULL,[space] [int] NULL,[DBType] [smallint] NULL,[DBField] [nvarchar](50) NULL,[FormatType] [nvarchar](10) NULL,[decimals] [int] NULL,[supress] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                'CREATE A ACCOUNTGROUPSLIST TABLE
                SQLFcmd.CommandText = "CREATE TABLE [AccountGroupsList]  ([groupname] [varchar](50) NOT NULL,	[subgroup] [varchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PriceList]([Pricelistname] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [UsedTranscodeList] ([Transcode] [bigint] NULL,[UsedTranscode] [bigint] NULL,[UsedDbName] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [EmailDb] ([EmailID] [nvarchar](150) NULL,[EmailPassword] [nvarchar](50) NULL,[ServerName] [nvarchar](50) NULL,[Port] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                'STOCK DATABASE


                SQLFcmd.CommandText = "CREATE TABLE [VoucherAccounts]([AccountName] [nvarchar](75) NULL,[Amount] [float] NULL,[IsDrCr] [int] NULL,[Transcode] [bigint] NULL,[VoucherNo] [nvarchar](50) NULL,[Sno] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [barcodeprintimages] ([Schemename] [nvarchar](50) NULL,[imagewidth] [int] NULL,[imageHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[imagepath] [nvarchar](250) NULL,[Orderno] [int] NULL,[IsVisible] [bit] NULL,[Imagename] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [barcodeprintlabels]([Schemename] [nvarchar](50) NULL,[Lwidth] [int] NULL,[LHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[DbName] [nvarchar](50) NULL,[LText] [nvarchar](50) NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[backcolor] [nvarchar](50) NULL,[Rotate] [int] NULL,[IsDbFiled] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [barcodePrintLines]([schemename] [nvarchar](50) NULL,[ltop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [int] NULL,[IsVisible] [bit] NULL,[fillcolor] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [BarcodePrintSchemes]([Schemename] [nvarchar](50) NULL,[Barcodewidth] [int] NULL,[BarcodeHeight] [int] NULL,[Lwidth] [int] NULL,[LHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[LVgap] [int] NULL,[LHgap] [int] NULL,[nocolumns] [int] NULL,[barcodetype] [nvarchar](50) NULL,[papertype] [nvarchar](50) NULL,[BarcodeLeft] [int] NULL,[BarcodeTop] [int] NULL,[barcodeColor] [nvarchar](75) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [logfile] ([StoreName] [nvarchar](50) NULL,[TransDatetime] [datetime] NULL,[Transcode] [float] NULL,[vouchername] [nvarchar](50) NULL,[voucherno] [nvarchar](50) NULL,[username] [nvarchar](50) NULL,[status] [nvarchar](50) NULL,[systemno] [nvarchar](50) NULL,[details] [nvarchar](250) NULL,[ID] [float] NULL,[TransDateValue] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockLocations] ([locationname] [nvarchar](50) NULL,[locationtemp] [nvarchar](50) NULL,[Isvisible] [int] NULL,[IsDefault] [int] NULL,[IsDelete] [int] NULL,[ADDRESS] [nvarchar](150) NULL,[CITY] [nvarchar](50) NULL,[contactno] [nvarchar](30) NULL,[contactperson] [nvarchar](75) NULL,[email] [nvarchar](100) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Categoriesgroups]([StockCategoryName] [varchar](50) NOT NULL,[StockCategoryNameTemp] [varchar](50) NOT NULL,[groupRoot] [varchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [DepartmentGroups]([DepName] [varchar](50) NOT NULL,[DepNameTemp] [varchar](50) NOT NULL,[groupRoot] [varchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [DepartmentsLists](	[groupname] [varchar](50) NOT NULL,	[subgroup] [varchar](50) NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [company]([companyname] [nvarchar](125) NULL,[licenseno] [nvarchar](70) NULL,[taxregno] [nvarchar](70) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[adminname] [nvarchar](50) NULL,[adminpassword] [nvarchar](50) NULL,[adminemailid] [nvarchar](120) NULL,[Isactive] [int] NULL,[logoimage] [nvarchar](255) NULL,[accyearstart] [datetime] NULL,[accyearend] [datetime] NULL,[booksyearstart] [datetime] NULL,[booksyearend]  [datetime] NULL,[Backupath] [nvarchar](255) NULL,[photopath] [nvarchar](255) NULL,[BarcodePath] [nvarchar](255) NULL,[LastAccessDate] [datetime] NULL,[Currency] [nvarchar](10) NULL,[Version] [int] NULL,[UpdateValue] [int] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[UserSecurityQ1] [nvarchar](125) NULL,[UserSecurityQ2] [nvarchar](125) NULL,[UserSecurityA1] [nvarchar](50) NULL,[UserSecurityA2] [nvarchar](50) NULL,[IsSizeBasedItem] [bit] NULL,[YearStartDate] [datetime] NULL,[YearEndDate] [datetime] NULL,[CurrencyName] [nvarchar](50) NULL,[Versionno] [int] NULL,[Versiontext] [nvarchar](50) NULL,[PeriodFrom] [datetime] NULL,[PeriodTo] [datetime] NULL,[CompanyID] [nvarchar](125) NULL, [CurrentDate] [DATETIME] NULL,[noofdecimals] [int] NULL,[CstNo] [nvarchar](50) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Godwons](	[GodownName] [nvarchar](50) NULL,	[GodownNameTemp] [nvarchar](50) NULL,	[IsDeleted] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'NEWTABLES

                SQLFcmd.CommandText = "CREATE TABLE [LockEditings]([FormCode] [bigint] NULL,[AccountName] [nvarchar](75) NULL,[SystemName] [nvarchar](50) NULL,[AccountNameCode] [int] NULL,[UserName] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [Bill2Bill]([BillType] [nvarchar](10) NULL,[LedgerName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[BillTransCode] [bigint] NULL,[Dr] [float] NULL,[Cr] [float] NULL,[RefNo] [nvarchar](50) NULL,[InvoiceNo] [nvarchar](50) NULL,[IsOpening] [int] NULL,[TransDate] [datetime] NULL,[StoreName] [nvarchar](50) NULL,[PayDays] [int] NULL,[VoucherName] [nvarchar](50) NULL,[PaymentMethod] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "  CREATE TABLE [StockBatch]([StockCode] [nvarchar](50) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[OpBaseQty] [float] NULL,[OpTotalQty] [float] NULL,[OpSubUnitQty] [float] NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[OpstockRate] [float] NULL,[mrp] [float] NULL,[expiryDateValue] [bigint] NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [LedgerBook] ([LedgerName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceName] [nvarchar](50) NULL,[sno] [int] NULL,[Dr] [float] NULL,[Cr] [float] NULL,[TransDate] [datetime] NULL,[TransDateValue] [float] NULL,[LedgerGroup] [nvarchar](75) NULL,[AcLedger] [nvarchar](75) NULL,[IsAdvance] [int] NULL,[IsDeleted] [int] NULL,[UserName] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[Narration] [nvarchar](250) NULL,[InvoiceType] [nvarchar](30) NULL,[RefNo] [nvarchar](50) NULL,[CurrencyCode] [nvarchar](8) NULL,[ConRate] [float] NULL,[Ddr] [float] NULL,[Dcr] [float] NULL,[N1] [int] NULL,[IsChequePrint] [bit] NULL,[ClearPDC] [bit] NULL,[F1] [nvarchar](50) NULL,[N2] [float] NULL,[TodaydateValue] [bigint] NULL,[IsPostDated] [bit] NULL,[TodayDate] [datetime] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [ExpiryHistory]([DocType] [nvarchar](50) NULL,[DocName] [nvarchar](50) NULL,[IDType] [nvarchar](50) NULL,[verifiedby] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[AlterDate] [datetime] NULL,[UserName] [nvarchar](75) NULL,[renewDate] [datetime] NULL,[RefNumber] [nvarchar](50) NULL,[RegNumber] [nvarchar](50) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[RegDate] [datetime] NULL,[Sno] [int] IDENTITY(1,1) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Vehicle]([VhType] [nvarchar](75) NULL,[VHRefNo] [nvarchar](50) NULL,[VHID] [nvarchar](50) NULL,[VHName] [nvarchar](75) NULL,[IssuedBy] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[RegNo] [nvarchar](50) NULL,[RegDate] [datetime] NULL,[VhNo] [nvarchar](50) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[Chasisno] [nvarchar](50) NULL,[EngineNo] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[AcountLedgerName] [nvarchar](75) NULL,[PhotoPath] [nvarchar](250) NULL,[IsDelete] [int] NULL,[IsActive] [int] NULL,[Status] [nvarchar](50) NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[DriverName1] [nvarchar](75) NULL,[DriverName2] [nvarchar](75) NULL,[AssistantName1] [nvarchar](75) NULL,[AssistantName2] [nvarchar](75) NULL,[Color] [nvarchar](20) NULL,[Model] [nvarchar](50) NULL,[MadeBy] [nvarchar](50) NULL,[InsurenceNo1] [nvarchar](50) NULL,[InsurenceDate1] [datetime] NULL,[InsurenceExpiry1] [datetime] NULL,[InsurenceNo2] [nvarchar](50) NULL,[InsurenceDate2] [datetime] NULL,[InsurenceExpiry2] [datetime] NULL,[InsurenceNo3] [nvarchar](50) NULL,[InsurenceDate3] [datetime] NULL,[InsurenceExpiry3] [datetime] NULL,[InsurenceDetails3] [nvarchar](150) NULL,[InsurenceDetails2] [nvarchar](150) NULL,[InsurenceDetails1] [nvarchar](150) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [CostCenters]([StockGroupName] [varchar](50) NOT NULL,[StockGroupNameTemp] [varchar](50) NOT NULL,[groupRoot] [varchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CostCenterList]([groupname] [varchar](50) NOT NULL,[subgroup] [varchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CostCenterBook]([sno] [int] NULL,[LedgerName] [nvarchar](75) NULL,[CostCenterName] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[UserName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[VoucherName] [nvarchar](50) NULL,[InvoiceNo] [nvarchar](50) NULL,[CostNo] [int] NULL,[CostCat] [nvarchar](75) NULL,[IsAdditional] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [CostCenterNames]([CostName] [nvarchar](75) NULL,[costgroup] [nvarchar](75) NULL,[n1] [float] NULL,[f1] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [ledgers] ([LedgerName] [nvarchar](75) NULL,[LedgerCode] [nvarchar](50) NULL,[TaxRegno] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[createdby] [nvarchar](50) NULL,[alterby] [nvarchar](50) NULL,[verifiedby] [nvarchar](50) NULL,[Isactive] [int] NULL,[creditlimit] [float] NULL,[discount] [float] NULL,[Contactperson] [nvarchar](75) NULL,[pdesignation] [nvarchar](50) NULL,[ptel] [nvarchar](20) NULL,[pphoneno] [nvarchar](20) NULL,[pemail] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[OpDr] [float] NULL,[OpCr] [float] NULL,[IsBillWise] [int] NULL,[photopath] [nvarchar](250) NULL,[currentbalance] [float] NULL,[partyaddresscity] [nvarchar](100) NULL,[StoreName] [nvarchar](50) NULL,[CreditPeriod] [float] NULL,[Currency] [nchar](10) NULL,[LedgerNameTemp] [nvarchar](75) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[n2] [float] NULL,[PriceLevel] [nvarchar](50) NULL,[Activity] [nvarchar](50) NULL,[BankAccNo] [nvarchar](50) NULL,[EnableChequePrinting] [bit] NULL,[pincode] [nvarchar](18) NULL,[IsAllowCostCentre] [bit] NULL,[Isprimary] [int] NULL,[IsSendEmail] [bit] NULL,[IsSendSMS] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'PrintDataLedgers
                SQLFcmd.CommandText = "CREATE TABLE [PrintDataLedgers] ([LedgerName] [nvarchar](75) NULL,[LedgerCode] [nvarchar](50) NULL,[TaxRegno] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[createdby] [nvarchar](50) NULL,[alterby] [nvarchar](50) NULL,[verifiedby] [nvarchar](50) NULL,[Isactive] [int] NULL,[creditlimit] [float] NULL,[discount] [float] NULL,[Contactperson] [nvarchar](75) NULL,[pdesignation] [nvarchar](50) NULL,[ptel] [nvarchar](20) NULL,[pphoneno] [nvarchar](20) NULL,[pemail] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[OpDr] [float] NULL,[OpCr] [float] NULL,[IsBillWise] [int] NULL,[photopath] [nvarchar](250) NULL,[currentbalance] [float] NULL,[partyaddresscity] [nvarchar](100) NULL,[StoreName] [nvarchar](50) NULL,[CreditPeriod] [float] NULL,[Currency] [nchar](10) NULL,[LedgerNameTemp] [nvarchar](75) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[n2] [float] NULL,[PriceLevel] [nvarchar](50) NULL,[Activity] [nvarchar](50) NULL,[BankAccNo] [nvarchar](50) NULL,[EnableChequePrinting] [bit] NULL,[pincode] [nvarchar](18) NULL,[IsAllowCostCentre] [bit] NULL,[Isprimary] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CurrencyList]([CurrencyName] [nvarchar](250) NULL,[CurrencyCode] [nvarchar](8) NULL,[CurrencySymbol] [nvarchar](8) NULL,[ConRate] [float] NULL,[Demicals] [int] NULL,[IsActive] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [DefLedgers]([LedgerName] [nvarchar](75) NULL,[LedgerType] [nvarchar](50) NULL,[UserName] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EditValues]([ChangedName] [nvarchar](75) NULL,[OldName] [nvarchar](75) NULL,[Databasetablename] [nvarchar](50) NULL,[FileName] [nvarchar](50) NULL,[IsUpdate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [InvoiceSettings]([InvoiceNumber] [bigint] NULL,[InvoicePreFix] [nvarchar](15) NULL,[InvoicePostFix] [nvarchar](15) NULL,[InvoiceMethod] [smallint] NULL,[PrintonSave] [smallint] NULL,[eachnarration] [smallint] NULL,[PrintingScheme1] [nvarchar](50) NULL,[PrintingScheme2] [nvarchar](50) NULL,[PrintingScheme3] [nvarchar](50) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [int] NULL,[N2] [int] NULL,[AllowDuplicate] [int] NULL,[VoucherName] [nvarchar](50) NULL,[location] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [UserDepartments]([UserID] [nvarchar](50) NULL,[DepName] [nvarchar](50) NULL,[Isdelete] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Duties]([EmpName] [nvarchar](75) NULL,[DutyType] [nvarchar](20) NULL,[TimeIn] [datetime] NULL,[TimeOut] [datetime] NULL,[datefrom] [datetime] NULL,[dateto] [datetime] NULL,[datefromvalue] [bigint] NULL,[datetovalue] [bigint] NULL,[sno] [int] NULL,[ETimeIn] [datetime] NULL,[ETimeOut] [datetime] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [Dutysettings] ([ShiftName] [nvarchar](50) NULL,[Timein] [datetime] NULL,[timeout] [datetime] NULL,[ShiftType] [nvarchar](50) NULL,[ETimeIn] [datetime] NULL,[ETimeOut] [datetime] NULL,[earlyinOT] [bit] NULL,[earlyin] [datetime] NULL,[lateoutOT] [bit] NULL,[lateout] [datetime] NULL,[breaktimefrom] [datetime] NULL,[breaktimeto] [datetime] NULL,[issingleshift] [bit] NULL,[totalmins] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()








                SQLFcmd.CommandText = "CREATE TABLE [Leaves] ([LeaveName] [nvarchar](50) NULL,[LeaveType] [nvarchar](25) NULL,[Maxno] [float] NULL,[ColorCode] [nvarchar](30) NULL,[LeaveCode] [nvarchar](4) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [EmpLeaves]([EmpName] [nvarchar](75) NULL,[LeaveDays] [int] NULL,[FromDate] [datetime] NULL,[FromDateValue] [bigint] NULL,[ToDate] [datetime] NULL,[ToDateValue] [bigint] NULL,[Narration] [nvarchar](200) NULL,[LeaveName] [nvarchar](50) NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[UserName] [nvarchar](75) NULL,[ForYear] [int] NULL,[n1] [int] NULL,[TransCode] [bigint] NULL,[LeaveCode] [nvarchar](5) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpAttend]([EmpName] [nvarchar](75) NULL,[StratTime] [datetime] NULL,[EndTime] [datetime] NULL,[Status] [nvarchar](4) NULL,[Transdatevalue] [bigint] NULL,[TransDate] [datetime] NULL,[OT] [float] NULL,[Others] [float] NULL,[period] [nvarchar](15) NULL,[LT] [float] NULL,[EStratTime] [datetime] NULL,[EEndTime] [datetime] NULL,[EStatus] [nvarchar](4) NULL,[TotalworkingMin] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [settings] ([SharedFolderName] [nvarchar](350) NULL,[IsBatchExpiry] [bit] NULL,[IsBillWise] [bit] NULL,[IsAutoPrinting] [bit] NULL,[IsAutoBackup] [bit] NULL,[IsAllowCashBankinJournal] [bit] NULL,[IsCustomBarcode] [bit] NULL,[IsAllowZeroValueStock] [bit] NULL,[IsAllowNagetiveStock] [bit] NULL,[IsFixedDate] [bit] NULL,[IsNewInvoiceOnSave] [bit] NULL,[IsAllowDuplicateRef] [bit] NULL,[IsAllowAllRef] [bit] NULL,[IsAllowPriceField] [bit] NULL,[F1] [bit] NULL,[F2] [bit] NULL,[F3] [bit] NULL,[F4] [bit] NULL,[F5] [bit] NULL,[F6] [bit] NULL,[F7] [bit] NULL,[IsAllowSalesOrders] [bit] NULL,[IsAllowPurchaseOrders] [bit] NULL,[IsAllowMemos] [bit] NULL,[IsAllowCurrency] [bit] NULL,[IsAllowDebitNote] [bit] NULL,[IsAllowCreditNote] [bit] NULL,[IsAllowChequePrinting] [bit] NULL,[IsRestartInvoiceNo] [bit] NULL,[IsAllowDeliveryNote] [bit] NULL,[IsAllowGReceiptNote] [bit] NULL,[CostingMethod] [nvarchar](50) NULL,[IsAllowChating] [bit] NULL,[IsLoadDashBoard] [bit] NULL,[isAllowMultiPriceLevels] [bit] NULL,[IsAllowPDC] [bit] NULL,[IsAllowMrngEvngShifts] [bit] NULL,[IsSingleEntryMode] [bit] NULL,[AllowNarrationinvouchers] [bit] NULL,[IsallowCostingforInvoice] [bit] NULL, [PosPriceList] [nvarchar](75) NULL,[IsMultiTaxRates] [bit] NULL,[SalesPricewithTax] [bit] NULL,	[StockPricewithTax] [bit] NULL,[IsAllowEmptyBatchNo] [bit] NULL,[IsAllowMultiSalesTax] [bit] NULL,	[IsAllowMultiPurchaseTax] [bit] NULL,[customPrint] [bit] NULL, [ZerotaxonPurchase] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [projecttable]([ProjectName] [nvarchar](50) NULL,[CatName] [nvarchar](50) NULL,[f1] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [smsmailsettings](	[vouchername] [nvarchar](50) NULL,	[msgtext] [nvarchar](max) NULL,	[isattachfile] [bit] NULL,	[IsEmail] [bit] NULL,[mailSubject] [nvarchar](75) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpSalaries]([EmpName] [nvarchar](75) NULL,[Salary] [float] NULL,[FromDate] [datetime] NULL,[Todate] [datetime] NULL,[Days] [int] NULL,[years] [float] NULL,[Gratuity] [float] NULL,[Ispaid] [bit] NULL,[paidamount] [float] NULL,[paiddate] [datetime] NULL,[paiddetails] [nvarchar](200) NULL,[increment] [float] NULL,[sno] [int] NULL,[currentSalary] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockDbf] ([StockName] [nvarchar](75) NULL,[StockCodeTemp] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Brand] [nvarchar](50) NULL,[Company] [nvarchar](50) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[category] [nvarchar](75) NULL,[ISBatch] [int] NULL,[StoreName] [nvarchar](50) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[OpBaseQty] [float] NULL,[OpTotalQty] [float] NULL,[OpSubUnitQty] [float] NULL,[StockRate] [float] NULL,[StockWRP] [float] NULL,[StockDRP] [float] NULL,[IsAdvance] [int] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[StockSizeTemp] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockImagePath] [nvarchar](250) NULL,[StockType] [int] NULL,[Isactive] [int] NULL,[CustBarcode] [nvarchar](50) NULL,[Myatpp] [float] NULL,[Tax] [float] NULL,[UnitCon] [float] NULL,[MinQty] [float] NULL,[OpstockRate] [float] NULL,[costmethod] [nvarchar](25) NULL,[Servicetax] [float] NULL,[AllowDiscount] [bit] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[allowserialnumbers] [bit] NULL,[Tax2] [float] NULL,[cst] [float] NULL,[IsTaxInclude] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockJournalDbf]([RefNo] [nvarchar](50) NULL,[Transcode] [bigint] NULL,[LocationFrom] [nvarchar](50) NULL,[LocationTo] [nvarchar](50) NULL,[transdate] [datetime] NULL,[StockName] [nvarchar](75) NULL,[StockCodeTemp] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[Isactive] [int] NULL,[CustBarcode] [nvarchar](50) NULL,[Isdelete] [int] NULL,[TransDateValue] [bigint] NULL,[sno] [int] NULL,[rate] [float] NULL,[presentRate] [float] NULL,[mrp] [float] NULL,	[packing] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [UserRights]([UserName] [nvarchar](75) NULL,[IsEdit] [bit] NULL,[IsAccess] [bit] NULL,[IsReadOnly] [bit] NULL,[IsDelete] [bit] NULL,[IsFullRights] [bit] NULL,[IsMaster] [bit] NULL,[IsOptions] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Users]([UserName] [nvarchar](50) NULL,[UserPassword] [nvarchar](50) NULL,[UserType] [int] NULL,[UserEmailID] [nvarchar](50) NULL,[UserID] [nvarchar](50) NULL,[UserSecurityQ1] [nvarchar](125) NULL,[UserSecurityQ2] [nvarchar](125) NULL,[UserSecurityA1] [nvarchar](50) NULL,[UserSecurityA2] [nvarchar](50) NULL,[UserDepartment] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[LocationName] [nvarchar](50) NULL,[LoginSystemName] [nvarchar](75) NULL,[LoginTime] [datetime] NULL,[IsActive] [bit] NULL,[IsLogin] [bit] NULL,[LogoutTime] [datetime] NULL,[RCode] [nvarchar](10) NULL,[SQLUserID] [nvarchar](50) NULL,[SQLpwd] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CrReportSettings]([LeftLogoOn] [bit] NULL,[LeftLogoPath] [nvarchar](350) NULL,[RightLogoOn] [bit] NULL,[RightLogoPath] [nvarchar](350) NULL,[HeaderOn] [bit] NULL,[HeaderPath] [nvarchar](350) NULL,[FooterOn] [bit] NULL,[FooterPath] [nvarchar](350) NULL,[PrintPageNos] [bit] NULL,[PrintCompanyName] [bit] NULL,[PrintAddress] [bit] NULL,[PrintTitle] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [UserLogFile] ([UserName] [nvarchar](50) NULL,[LoginTime] [datetime] NULL,[LogoutTime] [datetime] NULL,[LiveTime] [bigint] NULL,[SystemName] [nvarchar](75) NULL,[LoginTimeValue] [bigint] NULL,[Transcode] [bigint] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'END OF INVOICE NUMBER SETTINGS

                SQLFcmd.CommandText = "CREATE TABLE [InvoiceMoreDet]([Despatchto] [nvarchar](100) NULL,[Despatchaddress] [nvarchar](100) NULL,[despatchtax] [nvarchar](100) NULL,[despatchthrough] [nvarchar](100) NULL,[DespatchDestination] [nvarchar](100) NULL,[buyername] [nvarchar](100) NULL,[buyeraddress] [nvarchar](100) NULL,[buyertax] [nvarchar](100) NULL,[paymenterm] [nvarchar](100) NULL,[otherref] [nvarchar](100) NULL,[remarks] [nvarchar](100) NULL,[consgneename] [nvarchar](100) NULL,[consgneeaddress] [nvarchar](100) NULL,[delevaryto] [nvarchar](100) NULL,[delevarynoteno] [nvarchar](100) NULL,[orderno] [nvarchar](100) NULL,[delevaryterm] [nvarchar](100) NULL,[Transcode] [bigint] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [paysliptypes](	[settingname] [nvarchar](50) NULL,	[IsActive] [bit] NULL,	[ledgername] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [DUMMY]([F1] [nchar](10) NULL,[F2] [int] NULL,[F3] [nchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmployeeAttendence] ([EmpID] [nvarchar](50) NULL,[EmpName] [nvarchar](75) NULL,[EmpDate] [datetime] NULL,[EmpDateValue] [bigint] NULL,[Status] [smallint] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Employees] ([EmpID] [nvarchar](50) NULL,[EmpName] [nvarchar](75) NULL,[Gender] [nchar](10) NULL,[DateofBirth] [datetime] NULL,[Nationality] [nvarchar](50) NULL,[Education] [nvarchar](75) NULL,[DateofJoining] [datetime] NULL,[Designation] [nvarchar](75) NULL,[DepName] [nvarchar](50) NULL,[Contracttype] [nvarchar](50) NULL,[contractexpirydate] [datetime] NULL,[address] [nvarchar](75) NULL,[contactno] [nvarchar](50) NULL,[emailid] [nvarchar](75) NULL,[Paddress] [nvarchar](75) NULL,[pcontactno1] [nvarchar](22) NULL,[pcontactno2] [nvarchar](22) NULL,[pemailid] [nvarchar](50) NULL,[photopath] [nvarchar](225) NULL,[EmpPersonalID] [nvarchar](50) NULL,[bankcode] [nvarchar](50) NULL,[bankacno] [nvarchar](50) NULL,[fixedsalary] [money] NULL,[empbankacno] [nvarchar](50) NULL,[empbankname] [nvarchar](50) NULL,[empbankbranch] [nvarchar](50) NULL,[passportIDNo] [nvarchar](50) NULL,[passportIDissuedby] [nvarchar](50) NULL,[passportexpire] [datetime] NULL,[visaIDNo] [nvarchar](50) NULL,[visaIDissuedby] [nvarchar](50) NULL,[visaexpire] [datetime] NULL,[EmiratesDNo] [nvarchar](50) NULL,[Emiratesissuedby] [nvarchar](50) NULL,[Emiratesexpire] [datetime] NULL,[LabourcardDNo] [nvarchar](50) NULL,[Labourcardissuedby] [nvarchar](50) NULL,[Labourcardexpire] [datetime] NULL,[MedicalDNo] [nvarchar](50) NULL,[Medicalissuedby] [nvarchar](50) NULL,[Medicalexpire] [datetime] NULL,[SalaryType] [nvarchar](20) NULL,[EmpCity] [nvarchar](50) NULL,[PEmpCity] [nvarchar](50) NULL,[bankifsccode] [nvarchar](50) NULL,[bankmicrcode] [nvarchar](50) NULL,[Isactive] [int] NULL,[IsDelete] [int] NULL,[AssignedUserName] [nvarchar](75) NULL,[IsUser] [bit] NULL,[Barcode] [nvarchar](20) NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[basicsalary] [float] NULL,[allowance] [float] NULL,[CostCat] [nvarchar](75) NULL,[payslipmethod] [nvarchar](50) NULL,[rateperhour] [float] NULL,	[TeamName] [nvarchar](75) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Documents]([DocType] [nvarchar](75) NULL,[DocRefNo] [nvarchar](50) NULL,[DocID] [nvarchar](50) NULL,[DocName] [nvarchar](75) NULL,[IssuedBy] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[Location] [nvarchar](50) NULL,[ContactPerson] [nvarchar](50) NULL,[PersonAddress] [nvarchar](150) NULL,[IsDelete] [int] NULL,[IsActive] [int] NULL,[Status] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [IDsettings]([salespersonsID] [bigint] NULL,[EmployeeID] [bigint] NULL,[EmployeePerID] [bigint] NULL,[AreaID] [bigint] NULL,[TransCode] [bigint] NULL,[BarCodeEna8] [bigint] NULL,[Barcode128] [bigint] NULL,[ID] [bigint] NULL,[supID] [bigint] NULL,[custID] [bigint] NULL,[StockCode] [bigint] NULL,[AccountCode] [bigint] NULL,[logfileid] [float] NULL,[LockTransCode] [bigint] NULL,[BillTranscode] [bigint] NULL ,[UserTransCode] [bigint] NULL ,[AssetID] [bigint] NULL,[BudgetID] [bigint] NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [salespersons]([salespersonname] [nvarchar](75) NULL,[Address] [nvarchar](120) NULL,[Gender] [nchar](10) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[Isactive] [int] NULL,[per] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockCategoriesList]([groupname] [varchar](50) NOT NULL,[subgroup] [varchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockGroupList](	[groupname] [varchar](50) NOT NULL,	[subgroup] [varchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [assetgroupList](	[groupname] [varchar](50) NOT NULL,	[subgroup] [varchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockGroups]([StockGroupName] [varchar](50) NOT NULL,[StockGroupNameTemp] [varchar](50) NOT NULL,[groupRoot] [varchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [assetgroups]([AssetGroupName] [varchar](50) NOT NULL,[AssetGroupNameTemp] [varchar](50) NOT NULL,[groupRoot] [varchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                '
                SQLFcmd.CommandText = "CREATE TABLE [Stockunits]([UnitName] [nvarchar](75) NOT NULL,[MainUnitName] [nvarchar](25) NULL,[SubUnitName] [nvarchar](25) NULL,[UnitConversion] [numeric](18, 3) NULL,[UnitType] [int] NULL,[formalname] [nvarchar](70) NULL,[Decimals] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                '
                SQLFcmd.CommandText = "CREATE TABLE [Vatclauses]([VatName] [nvarchar](75) NULL,[vattax] [float] NULL,[inputvatledger] [nvarchar](75) NULL,[outputvatledger] [nvarchar](75) NULL,[PurchaseLedger] [nvarchar](75) NULL,[DebitNoteLedger] [nvarchar](75) NULL,[SalesLedger] [nvarchar](75) NULL,[CreditLedger] [nvarchar](75) NULL,[isactive] [bit] NULL,[Vattype] [nvarchar](15) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockInvoiceDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                'PrintDataDetails

                SQLFcmd.CommandText = "CREATE TABLE [PrintDataDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockInvoiceRowItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](18) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](30) NULL,[Servicetax] [float] NULL,	[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'CREATE TABLE [PrintingDataRowsItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](18) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](10) NULL,[Servicetax] [float] NULL,[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                SQLFcmd.CommandText = "CREATE TABLE [PrintingDataRowsItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](18) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](10) NULL,[Servicetax] [float] NULL,[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'INSERT VALUES INTO TABLES

                'DEFAULT VALUES FOR TABLES

                SQLFcmd.CommandText = "CREATE TABLE [LockTrans]([TransCode] [bigint] NULL,[UserName] [nvarchar](50) NULL,[SystemName] [nvarchar](50) NULL,[Details] [nvarchar](250) NULL,[TransDate] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Request]([ReqNo] [bigint] NULL,[ReqSystemName] [nvarchar](75) NULL,[Status] [char](1) NULL,[UserName] [nvarchar](50) NULL,[SystemName] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpGratuityMethods]([Method] [nvarchar](70) NULL,[Years] [int] NULL,[Price] [float] NULL,[MethodValue] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                If IsEmptyDatabase = False Then

                    Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
                    Dim cnn As SqlConnection
                    cnn = New SqlConnection(ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";")
                    cnn.Open()
                    Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    For Each row As DataRow In ds.Tables(0).Rows
                        Try
                            Dim ids As New DataSet
                            Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                            dscmd.Fill(ids, row.Item("TABLE_NAME"))
                            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                            ids.ReadXml(Application.StartupPath & "\DbScripts\" & row.Item("TABLE_NAME") & ".xml")
                            dscmd.Update(ids, row.Item("TABLE_NAME"))

                        Catch ex As Exception

                        End Try
                    Next row
                    da.Dispose()
                    ds.Dispose()
                    cnn.Close()
                    cnn.Dispose()

                    SQLFcmd.CommandText = "USE " & NewCompanyDBName
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [Categoriesgroups] ([StockCategoryName],[StockCategoryNameTemp],[groupRoot],[grouplevel])  VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DepartmentGroups]([DepName],[DepNameTemp],[groupRoot],[grouplevel])   VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [settings]([SharedFolderName],[IsBatchExpiry],[IsBillWise],[IsAutoPrinting],[IsAutoBackup],[IsAllowCashBankinJournal],[IsCustomBarcode],[IsAllowZeroValueStock],[IsAllowNagetiveStock],[IsFixedDate],[IsNewInvoiceOnSave],[IsAllowDuplicateRef],[IsAllowAllRef],[IsAllowPriceField] ,[F1] ,[F2] ,[F3] ,[F4] ,[F5] ,[F6] ,[F7],[IsAllowSalesOrders],[IsAllowPurchaseOrders],[IsAllowMemos],[IsAllowCurrency],[IsAllowDebitNote],[IsAllowCreditNote],[IsAllowChequePrinting],[IsRestartInvoiceNo],[IsAllowDeliveryNote],[IsAllowGReceiptNote],[CostingMethod],[IsAllowChating],[IsLoadDashBoard],[isAllowMultiPriceLevels],[IsAllowPDC],[IsAllowMrngEvngShifts],[IsSingleEntryMode],[AllowNarrationinvouchers],[IsallowCostingforInvoice],[IsMultiTaxRates],[SalesPricewithTax],[StockPricewithTax],[IsAllowEmptyBatchNo],[IsAllowMultiSalesTax],[IsAllowMultiPurchaseTax],[customPrint],[ZerotaxonPurchase] )     VALUES ('','False','True','False','False','False','False','True','True','False','False','True','True','True','False','False','False','False','False','False','False','True','True','True','True','True','True','True','True','True','True','True','True','True','True','True','True','False','True','False','False','False','False','False','False','False','False','False') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()



                    SQLFcmd.CommandText = "INSERT INTO [StockGroups] ([StockGroupName],[StockGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [assetgroups] ([AssetGroupName],[AssetGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [CostCenters] ([StockGroupName],[StockGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [Godwons] ([GodownName],[GodownNameTemp],[IsDeleted]) VALUES ('MainLocation','MainLocation',0) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [IDsettings] ([salespersonsID],[EmployeeID],[EmployeePerID],[AreaID],[TransCode],[BarCodeEna8],[Barcode128],[ID],[supid],[custid],[stockcode],[AccountCode],[LockTransCode],[logfileid],[BillTranscode],[UserTransCode],[AssetID] ,[BudgetID]) VALUES (1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [StockLocations] ([locationname],[locationtemp],[Isvisible],[IsDefault],[IsDelete],[ADDRESS],[CITY],[contactno],[contactperson],[email]) VALUES ('MainLocation','MainLocation',1,1,0,'','','','','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'DEFAULT INVOICE VALUES

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SI','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SO','MainLocation') "

                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SQ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SD','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PI','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PO','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PQ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PG','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PVR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CON','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PAY','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'REC','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'JOUR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'POS','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PAY','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SJ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8B','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8D','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8B','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8D','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CashSales','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CreditSales','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CashPurchase','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CreditPurchase','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceDisplaySettings]([ShowTax],[ShowNetRate],[ShowItemName],[ShowItemCode],[ShowItemMoreInfo],[ShowDiscount],[ShowAccount],[ShowRatePer],[ShowNarration],[ShowCurrentBalance],[isallowdisc2])     VALUES ('False','False','True','True','True','True','True','True','True','True','False')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()



                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','cash','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','sales','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','salesret','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purch','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purchret','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    ' sales discount ledger (indirect expenses)
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Cd Dr','cddr','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for purchase discount ledger (indirect incomes)
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Cd Cr','cdcr','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for rounding ledger account
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Round Off','round','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for commision account ledger account
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Commission A/c','comm','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('cash','pos','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','profit','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'cheque printing values
                    SQLFcmd.CommandText = "INSERT INTO [chequePrintingSettings] ([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat],[Watermark])     VALUES ('Microsoft XPS Document Writer ', 'SBI',650,350, 'FALSE',10,10,10,10, 'FALSE', 'TRUE', 'TRUE', 'TRUE', 'FALSE', 'FALSE',0,20,12,60,650,14,80,80,  '', '',31,19, 'FALSE',1100,570,1, '')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintingSchemes]([SchemeName],[VoucherName],[IsActive],[ID])     VALUES ('SBI','SBI',1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES( 'SBI', 'DateLine', '', 'TransDate', 'TRUE',10,500,10,10, 'Microsoft Sans Serif',8,8, 'Black', 'Left',10,550,10,10, 'Arial',10,2, 'Black', 'left', '12-05-2010',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DUMMY]([F1],[F2],[F3])     VALUES ('jyo',1,'thi')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'Pay Name', '', 'LedgerName', 'TRUE',55,27,10,10, 'Microsoft Sans Serif',10,8, 'Black', 'Left',10,10,10,10, 'Arial',10,2, 'Black', 'left', 'Jyothi Suresh',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES (  'SBI', 'Amount', '', 'Amount', 'TRUE',120,500,10,10, 'Microsoft Sans Serif',12,1, 'Black', 'Left',10,10,10,10, 'Arial',10,2, 'Black', 'left', '652554.48',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [CrReportSettings]([LeftLogoOn],[LeftLogoPath],[RightLogoOn],[RightLogoPath],[HeaderOn],[HeaderPath],[FooterOn],[FooterPath],[PrintPageNos],[PrintCompanyName],[PrintAddress],[PrintTitle])     VALUES('False','','False','','False','','False','','True','True','True','True')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'AmountWordsLine1', '', 'AmountLine1', 'TRUE',82,35,900,20, 'Microsoft Sans Serif',11,8, 'Black', 'Left',82,30,200,10, 'Arial',10,2, 'Black', 'left', 'INR : Six Laks and Fifty Two Thousand and Fify Four ',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'AmountWordsLine2', '', 'AmountLine2', 'TRUE',117,10,10,10, 'Microsoft Sans Serif',12,8, 'Black', 'Left',110,10,10,10, 'Arial',10,2, 'Black', 'left', 'and fourty eight Paise Only',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                End If
                SQLFcmd.CommandText = "update PrintingSchemes set SchemeType=1 where id=21 or id=20 or id=22"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                'StockInvoiceDetails
                'StockInvoiceRowItems
                'IsDirect


                'DEFAULT COLUMNS VALUES
                SQLFcmd.CommandText = "ALTER TABLE [LedgerBook] ADD  CONSTRAINT [DF_LedgerBook_ClearPDC]  DEFAULT ((1)) FOR [ClearPDC]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER TABLE [StockInvoiceDetails] ADD  CONSTRAINT [DF_LedgerBook_IsDirect]  DEFAULT (('False')) FOR [IsDirect]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE [StockInvoiceRowItems] ADD  CONSTRAINT [DF_LedgerBook_IsDirect5]  DEFAULT (('False')) FOR [IsDirect]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER TABLE [LedgerBook] ADD  CONSTRAINT [DF_LedgerBook_IsPostDated]  DEFAULT ((0)) FOR [IsPostDated]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                '

                ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";"

                If IsEmptyDatabase = False Then
                    ReArrangeAccountGroups()
                    ReArrangeStockCategories()
                    ReArrangeStockGroups()
                    ReArrangeCostCenterGroups()
                    ReArrangeAssetTypes()
                End If

                iscreateD = True

            Catch ex As Exception
                MsgBox(ex.Message)
                iscreateD = False
            End Try
            MainSqlConn.Close()

        Catch ex As Exception
            iscreateD = False
        End Try
        Return iscreateD


    End Function

End Module
