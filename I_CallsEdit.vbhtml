@ModelType SW_TestCust.Models.CallsEditModel

@Code
    'ViewData("Title") = "CallsEdit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<script src="~/Content/sweetalert/sweetalert.min.js"></script>
<link href="~/Content/sweetalert/sweet-alert.css" rel="stylesheet" />

<link href="@Url.Content("~/Content/bootstrapDatePicker.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Scripts/jquery-ui.css")" rel="stylesheet" type="text/css" />
<script id="dxss_myCode1" src=@Url.Content("~/Scripts/moment.js") type="text/javascript"></script>
<script id="dxss_myCode2" src=@Url.Content("~/Scripts/bootstrap-datetimepicker.js") type="text/javascript"></script>
@*<script id="dxss_myCode3" src="~/Content/Script/SessionTimeOut.js"></script>*@
<script id="dxss_myCode4">
    //function CloseModal() {
    //    e.preventDefault();
    //    $('#modal_img').modal('hide');
    //    $('#modal_pdf').modal('hide');
    //    $('#modal').modal('hide');

    //}
    //function openfileinModal2(blobID, fileext) {

    //    $("#Viewerpdf").attr("src", "");
    //    $("#modal_img_target").attr("src", "");
    //    var d = '#img-thumbnail' + blobID
    //    var src = $(d).attr('src');
    //    if (fileext == '2') {
    //        $("#Viewerpdf").attr("src", src);

    //    }
    //    else {
    //        $("#modal_img_target").attr("src", src);
    //        $('#modal_pdf').modal('hide');
    //    }



    //    $("#modal").removeClass("hide");
    //    $('#modal').modal('show');
    //}


    function openfileinModal2(blobID, fileext) {
        $("#Viewerpdf").attr("src", "");
        $("#modal_img_target").attr("src", "");
        var d = '#img-thumbnail' + blobID
        var src = $(d).attr('src');

        $("#modal_pdf").removeAttr("style").hide();
        $("#modal_img").removeAttr("style").hide();
        if (fileext == '2') {
            $("#Viewerpdf").attr("src", src);
            $("#modal_pdf").show();
        }
        else {
            $("#modal_img_target").attr("src", src);
            $("#modal_img").show();
        }

        modalFileViewer.Show();
    }

    $(document).ready(function () {

        $('[data-toggle="tooltip"]').tooltip();

        $("[id^='datetimepicker']").datetimepicker({
            format: 'L',
            useCurrent: false
        });

        $('#dateRequestDiv').datetimepicker({
            format: 'L',
            useCurrent: false
        });

        var ReqType = $("#ProblemID").val()
        if (ReqType == "169" || ReqType == "170") {
            $("#datetimeRequest2").datetimepicker({
                format: 'LT',
                disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                useCurrent: false
            });
            $('#datetimeRequest').datetimepicker({
                format: 'LT',
                disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                useCurrent: false
            });
        }
        else {

            $("#datetimeRequest2").datetimepicker({
                format: 'LT',
                useCurrent: false
            });

            $('#datetimeRequest').datetimepicker({
                format: 'LT',
                minDate: moment(),
                disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                useCurrent: false
            });

        }


        $('input[type="text"]').keyup(function (event) {
            if (this.id == "txtQuickSearchText") {
                //Do nothing
            }
            //else {
            //    if (event.keyCode === 13) {
            //        $("#btnSaveVisible").click();
            //    }
            //}
        });


        //Set breadcrumbs of page without Sitemap node
        var breadcrumbs = document.getElementById("navbar_breadcrumb");
        var homeButton = document.getElementById("homeButton");
        if (breadcrumbs.innerText == "") {
            var homeLink = "<a href='" + homeButton.href + "' target>ServiceWeb</a>"
            breadcrumbs.innerHTML = homeLink + " > Call Information > Call Details"
        }

        var notes = document.getElementById("RandDList_0__RandDNotes")
        var internalNotes = document.getElementById("Internal_Notes")
        var custNotes = document.getElementById("Cust_Notes")
        document.getElementById("frmCall").addEventListener('keydown', function (e) {
            if (e.keyCode === 13) {
                if (e.target == notes || e.target == internalNotes || e.target == custNotes) {
                    //Do nothing b/c textarea
                }
                else {
                    e.preventDefault();
                }
            }
        });


        $('#dateRequestDiv').datetimepicker({
            format: 'L',
            minDate: new Date().setHours(0, 0, 0, 0),
            keepInvalid: true
        }).on('dp.change', function (e) {
            var datenow = $("#DateNow").val()
            var ReqDate = $("#RequestDateTxt").val()
            var ReqType = $("#ProblemID").val()

            datenow = datenow.replace(".", "/")
            datenow = datenow.replace(".", "/")

            var datenowsplit = datenow.split('/')
            var ReqDatesplit = ReqDate.split('/')


            if (datenowsplit[0].length == 1) {
                var month
                var day = '0' + datenowsplit[0]
                if (datenowsplit[1].length == 1) {
                    var month = '0' + datenowsplit[1]
                }
                datenow = day + '/' + month + '/' + datenowsplit[2]

            }

            if (ReqDatesplit[0].length == 1) {
                var month
                var day = '0' + ReqDatesplit[0]
                if (ReqDatesplit[1].length == 1) {
                    var month = '0' + ReqDatesplit[1]
                }
                ReqDate = day + '/' + month + '/' + ReqDatesplit[2]

            }
            //1=162, 15=164 Apply Hot Fixes
            if (ReqType == "162" || ReqType == "164" || ReqType == "169" || ReqType == "170" || ReqType == "143" || ReqType == "144") {

                if (ReqType == "143" || ReqType == "144" || ReqType == "169" || ReqType == "170") {

                    $('#DivReboot').hide();
                    $('#DivHotFixes').hide();
                    $('#RequestTime').val(datenow)
                    $('#datetimeRequest').datetimepicker({
                        format: 'LT',
                        disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                    });
                }

                if (datenow == ReqDate) {

                    if (ReqType == "164") {
                        $('#datetimeRequest').datetimepicker({
                            format: 'LT',
                            minDate: moment()

                        });

                    }
                    else if (ReqType == "169" || ReqType == "170") {
                        $('#datetimeRequest').datetimepicker({
                            format: 'LT',
                            disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                        });
                        $('#datetimeRequest2').datetimepicker({
                            format: 'LT',
                            disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                        });
                    }
                    else {
                        $('#datetimeRequest').datetimepicker({
                            format: 'LT',
                            minDate: moment(),
                            disabledHours: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16']
                        });
                    }



                    // var ReqTime = $("#RequestTimeAllHours").val()

                    //// if (ReqTime !== "") {
                    //     if (ReqTime !== "[object HTMLDivElement]") {
                    //         $("#RequestTime").val(ReqTime)
                    //     }
                    //// }
                    $("#RequestTimeAllHourstextBox").val();
                    $("#RequestTimeAllHours").val();
                    $("#RequestTimetextBox").val();
                    $('#DivTimePastTime').hide();
                    $('#DivTimeNoPastTime').show();


                }
                else {

                    $('#datetimeRequest').datetimepicker({
                        format: 'LT'
                    });

                    $('#datetimeRequest2').datetimepicker({
                        format: 'LT'
                    }).on('dp.change', function (e) {

                        //$("#RequestTime").val(this)
                        //$("#RequestTime").val($("#datetimeRequest2").val())
                    });

                    if (ReqType == "169" || ReqType == "170") {
                        $('#datetimeRequest2').datetimepicker({
                            format: 'LT',
                            disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                        });
                    }

                    var ReqTime = $("#RequestTimetextBox").val()
                    if (ReqTime !== "") {

                        $("#RequestTimeAllHourstextBox").val(ReqTime);
                    }

                    $('#DivTimePastTime').show();
                    $('#DivTimeNoPastTime').hide();


                }


            }


        });
    })

    $(document).ready(function () {
        keepAliveCallsFunc();
    });

    function keepAliveCallsFunc() {
        // Will refresh every 10 minutes.
        window.setInterval(keepAliveCalls, 600000);
    };

    function keepAliveCalls() {
        console.log("Refresh Calls");
        //GridCallActions.Refresh();
        //SaveRefreshAction();
        SaveRefreshFileGrid();
    };

    function ReopenPopup(chekSel, id) {
        var reopenedCall = document.getElementById("SplitCallOpen_Reopend");
        var reopenedCallRefNo = document.getElementById("SplitCallOpen_RefNo");

        if (reopenedCall.value == "True" && chekSel.checked == true) {
            var dataToSend = chekSel.checked;
            var errorTitle = "Are you sure you want to Re-Open this call?";
            var errorText = "This call has already been reopened and files have been transferred to <br/> " + reopenedCallRefNo.value + ".";

            swal({
                title: errorTitle,
                text: errorText,
                type: "warning",
                html: true,
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes",
                cancelButtonText: "No",
                closeOnConfirm: true,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm == true) {
                        document.getElementById("ReopenCall").checked = true;
                    }
                    else {
                        document.getElementById("ReopenCall").checked = false;
                    }
                });
        }
    }

    $(document).on('submit', 'form', function (event) {
        var buttons = $(this).find('[type="submit"]');
        if ($(this).valid()) {
            buttons.each(function (btn) {
                $("#btnSaveVisible").prop('disabled', true);
            });
        } else {
            buttons.each(function (btn) {
                $('#btnSaveVisible').prop('disabled', false);
            });
        }
    });

    function ShowCallEmail(title) {
        popupCallEmail.SetHeaderText(title);
        popupCallEmail.Show();
    }

    function ShowFileViewer(title) {
        modalFileViewer.SetHeaderText(title);
        modalFileViewer.Show();
    }

    function ClosingFileViewer(s, e) {
        modalFileViewer.SetContentHtml("<div id='callFileViewer'></div>");
    }
</script>
<script src="~/Content/sweetalert/sweetalert.min.js"></script>
<link href="~/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


<script type="text/javascript">
    function OnEndCallbackFiles(s, e) {
        var fileRowCount = document.getElementById("fileRowCount");
        fileRowCount.value = s.cpVisibleRowCount;
    }
    function Save() {
        //var module = document.getElementById("MASModuleList");
        //var header = document.getElementById("MASHeaderList");
        //var title = document.getElementById("TitleMenuItem");
        //var selection = document.getElementById("SelectionID");
        //var sequence = document.getElementById("Sequence");
        //var error = document.getElementById("menuPathError");
        //var errorSeq = document.getElementById("selSeqError");
        //var errorHit = false;
        //error.innerHTML = "";
        //errorSeq.innerHTML = "";
        //if (module.value == "" || header.value == "" || module.vaule == "-1" || header.value == "-2" //|| title.value == ""
        //    || selection.value == "0" || sequence.value == "0" || selection.value == "" || sequence.value == "") {
        //    if (((module.value != "" && module.value != "-1") && (header.value != "" && header.value != "-2")) //&& title.value != ""
        //        || ((selection.value != "0" && selection.value != "") && (sequence.value != "0" && sequence.value != ""))) {

        //    }
        //    else {
        //        if (((module.value == "" || module.value == "-1") && (header.value == "" || header.value == "-2")) && //title.value == "") &&
        //            ((selection.value == "0" || selection.value == "") && (sequence.value == "0" || sequence.value == ""))) {
        //            error.innerHTML = "Either Menu Path or SelectionID/Seq is Required.";
        //            errorHit = true;
        //            return false;
        //        }
        //        if (errorHit == false && (((selection.value == "0" || selection.value == "") || (sequence.value == "0" || sequence.value == ""))
        //            && ((module.value == "" || module.value == "-1") && (header.value == "" || header.value == "-2")))) { // && title.value == ""))) {
        //            errorSeq.innerHTML = "This field is required.";
        //            errorHit = true;
        //            return false;
        //        }
        //        if (errorHit == false && (((module.value == "" || module.value == "-1")
        //            || (header.value == "" || header.value == "-2"))
        //            //|| title.value == "")
        //            && ((selection.value == "0" || selection.value == "") && (sequence.value == "0" || sequence.value == "")))) {
        //            error.innerHTML = "This field is required.";
        //            errorHit = true;
        //            return false;
        //        }
        //    }
        //}

        var qID = document.getElementById("Qid");
        var previousQID = document.getElementById("previousQID");
        var internalNotes = document.getElementById("Internal_Notes");
        var callNotes = document.getElementById("Cust_Notes");
        var invalidCT = document.getElementById("callTypeNoTesting");
        var invalidCC = document.getElementById("companyCodeNoNotes");
        var callTypeDDL = document.getElementById("CallTypeID");
        var ctError = document.getElementById("callTypeError");
        var quError = document.getElementById("queueError");
        var notesError = document.getElementById("notesError");
        var gsSupported = document.getElementById("GS_Version_Supported");
        var randdQueue = document.getElementById("randdQueue");
        var serviceQueue = document.getElementById("serviceQueue");
        var quoteQueue = document.getElementById("quoteQueue");
        var fileRowCount = document.getElementById("fileRowCount");
        var probTypeDDL = document.getElementById("ProblemID");
        var ptError = document.getElementById("probTypeError");
        var tlGrp = document.getElementById("tlGrp");
        var bAdmin = document.getElementById("bAdmin");
        ptError.innerHTML = "";
        if (probTypeDDL.value == "135" || probTypeDDL.value == "136" || probTypeDDL.value == "137" || probTypeDDL.value == "") {
            //When Accounting, Technical, or Operations (Created_Internally = 0)
            ptError.innerHTML = "Not a vaild Problem Type"
            var callInfoDiv = document.getElementById("callInfo");
            if (callInfoDiv.style.display === "none") {
                ShowPanel(btnCallInfo, callInfo);
            }
            probTypeDDL.focus();
            return false;
        }
        ctError.innerHTML = "";
        if (qID.value == "182" && invalidCT.value.includes(callTypeDDL.value)) {
            ctError.innerHTML = "Not a valid Call Type for the selected Queue!";
            var callInfoDiv = document.getElementById("callInfo");
            if (callInfoDiv.style.display === "none") {
                ShowPanel(btnCallInfo,callInfo);
            }
           callTypeDDL.focus();
            return false;
        }
        notesError.innerHTML = "";
        if (qID.value != previousQID.value) {
            if (invalidCC.value.includes("@Model.GSS_CustNo") == false && callNotes.value == "") {
                notesError.innerHTML = "Customer notes are required for a Queue Transfer!";
                var actionSectionDiv = document.getElementById("actionSection");
                if (actionSectionDiv.style.display === "none") {
                    ShowPanel(btnActionSection,actionSection);
                }
                callNotes.focus();
                return false;
            }

            quError.innerHTML = "";
            if (gsSupported.value == false) {
                if (randdQueue.value.includes(qID.value)) {
                    quError.innerHTML = "Call can not be transferred to R&D!";
                    var callInfoDiv = document.getElementById("callInfo");
                    if (callInfoDiv.style.display === "none") {
                        ShowPanel(btnCallInfo,callInfo);
                    }
                    qID.focus();
                    return false;
                }
            }
            if (quoteQueue.value.includes(previousQID.value) && (tlGrp.value != 32 && tlGrp.value != 49 && tlGrp.value != 42 && tlGrp.value != 59 && bAdmin.value == "False")) { //Only Custom (Custom - theResistance, ANT, Continuous Improvement Group) and SW Admin can transfer call
                quError.innerHTML = "Call can not be transferred unless by someone in Custom!";
                var callInfoDiv = document.getElementById("callInfo");
                if (callInfoDiv.style.display === "none") {
                    ShowPanel(btnCallInfo, callInfo);
                }
                qID.focus();
                return false;
            }
            //if (randdQueue.value.includes(qID.value)) {
            //    var clinicCode = document.getElementById("clinicCode");
            //    var clinicCodeName = ""
            //    if (clinicCode != null) {
            //        clinicCodeName = clinicCode.value;
            //    }
            //    if (fileRowCount == 0 || clinicCodeName == "") {
            //        quError.innerHTML = "Call must have file(s) and a Clinic Code to transfer to R&D";
            //        var callInfoDiv = document.getElementById("callInfo");
            //        if (callInfoDiv.style.display === "none") {
            //            ShowPanel(btnCallInfo,callInfo);
            //        }
            //        return false;
            //    }
            //}
        }
        if (invalidCC.value.includes("@Model.GSS_CustNo") == false && callNotes.value == "") {
            notesError.innerHTML = "Customer notes are required!";
            var actionSectionDiv = document.getElementById("actionSection");
            if (actionSectionDiv.style.display === "none") {
                ShowPanel(btnActionSection,actionSection);
            }
            callNotes.focus();
            return false;
        }

        var menuError = document.getElementById("menuPathError");
        menuError.innerHTML = "";
        var issueNumber = document.getElementById("RandDList_0__ExhibitsIssue");
        var menuID = GSSMenuItemsList.GetValue();
        if (issueNumber.value != "") {
            if (menuID == "" || menuID == "0" || menuID == null) {
                menuError.innerHTML = "Menu Item is required since there is an Issue associated!";

                GSSMenuItemsList.focus();
                return false;
            }
        }

        var closedCheck = document.getElementById("CloseCall");
        var qaCreated = document.getElementById("QACreated");
        if(closedCheck != null){
            if (closedCheck.checked == true) {
                if (qID.value == "799") {
                    quError.innerHTML = "Calls cannot be closed in the LMS VIP queue please transfer to close!";
                    var callInfoDiv = document.getElementById("callInfo");
                    if (callInfoDiv.style.display === "none") {
                        ShowPanel(btnCallInfo, callInfo);
                    }
                    qID.focus();
                    return false;
                }

                var billable = document.getElementById("BillingList_0__Billable");
                var billingAmt = document.getElementById("BillingList_0__TotalAmtBilled");
                var billingError = document.getElementById("billingError");
                billingError.innerHTML = "";
                if (billable.checked == true && billingAmt.value == "") {
                    billingError.innerHTML = "Either the billing amount needs to be applied or Billable needs to unchecked for call to be closed!";
                    var billingInfoDiv = document.getElementById("billingInfo");
                    if (billingInfoDiv.style.display === "none") {
                        ShowPanel(btnBillingInfo,billingInfo);
                    }
                    billable.focus();
                    return false;
                }
                //var issueStatus = document.getElementById("RandDList_0__ExhibitsIssueStatus");
                var issueStatusID = document.getElementById("RandDList_0__ExhibitsIssueStatusID");
                var issueNumber = document.getElementById("RandDList_0__ExhibitsIssue");
                var issuesError = document.getElementById("issuesError");
                issuesError.innerHTML = "";
                if (issueNumber.value != "") {
                    //if (issueStatus.value == "Dead Issue" || issueStatus.value == "Resolved" || issueStatus.value == "Released" || issueStatus.value == "Update") {
                    // Resolved: 5, Released: 6, Update: 7, Dead Issue: 8
                    if (issueStatusID.value == "5" || issueStatusID.value == "6" || issueStatusID.value == "7" || issueStatusID.value == "8") {

                    } else
                    {
                        issuesError.innerHTML = "Issue Status needs to be either Dead Issue, Resolved, Released, or Update for the Call to be closed!";
                        var randdInfoDiv = document.getElementById("randdInfo");
                        if (randdInfoDiv.style.display === "none") {
                            ShowPanel(btnRandDInfo,randdInfo);
                        }
                        issueNumber.focus();
                        return false;
                    }
                }
                if (qID.value == "0") {
                    quError.innerHTML = "Call must be transferred to another queue before it can be closed!";
                    var callInfoDiv = document.getElementById("callInfo");
                    if (callInfoDiv.style.display === "none") {
                        ShowPanel(btnCallInfo,callInfo);
                    }
                    qID.focus();
                    return false;
                }
                if (qaCreated.value == "True" && (tlGrp.value != 37 && bAdmin.value == "False")) { //Only QA and SW Admin can close call
                    swal({
                        title: "Call can only be closed by someone in QA!",
                    })
                    return false;
                }
            }
        }


        var bOkayToProceed = true;
        //Cloud Saving validation
        var panel = document.getElementById("callCloud");
        if (panel.style.display === "block" && closedCheck.checked == false) {
            var ReqDateFormOrig = $("#hdnRequestDate_Orig").val();
            var origSelectedDate  = new Date(ReqDateFormOrig)
            ReqDateFormOrig = (origSelectedDate.getMonth() + 1) + "/" + origSelectedDate.getDate() + "/" + origSelectedDate.getFullYear()
            var minutes
            var ReqDateForm = $("#RequestDateTxt").val()
            var ReqTime2 = $("#RequestTimeAllHourstextBox").val()
            var ReqTime = $("#RequestTimetextBox").val()
            var Notes = $("#Request_Notes").val()
            var FW = $("#CloudList_0__FireWall_Info").val()
            var VPN = $("#CloudList_0__VPN_Info").val()
            var Wan = $("#CloudList_0__Wan_Info").val()
            var Servers = $('#Serversid').val()

            var datenowFromVB = $("#DateNow").val()
            var Timenow = $("#TimeNow").val()

            var datenow
            var ReqDate
            var ReqDateOrig

            datenowFromVB = datenowFromVB.replace(".", '/')
            datenow = datenowFromVB.replace(".", '/')
            var datenowsplit = datenowFromVB.split('/')
            var ReqDatesplit = ReqDateForm.split('/')
            $("#RequestDate").val(ReqDateForm)

            if (ReqDatesplit[0].length == 1) {
                var monthReqDate
                var dayReqDate = '0' + ReqDatesplit[0]
                if (ReqDatesplit[1].length == 1) {
                    monthReqDate = '0' + ReqDatesplit[1]
                }
                else {
                    monthReqDate = ReqDatesplit[1]
                }
                ReqDate = dayReqDate + '/' + monthReqDate + '/' + ReqDatesplit[2]
            }
            else if (ReqDatesplit[0].length == 2) {
                ReqDate = ReqDateForm
            }

            var ReqDateOrigsplit = ReqDateFormOrig.split('/')

            if (ReqDateOrigsplit[0].length == 1) {
                var monthReqDate
                var dayReqDate = '0' + ReqDateOrigsplit[0]
                if (ReqDateOrigsplit[1].length == 1) {
                    monthReqDate = '0' + ReqDateOrigsplit[1]
                }
                else {
                    monthReqDate = ReqDateOrigsplit[1]
                }
                ReqDateOrig = dayReqDate + '/' + monthReqDate + '/' + ReqDateOrigsplit[2]
            }
            else if (ReqDateOrigsplit[0].length == 2) {
                ReqDateOrig = ReqDateFormOrig
            }

            if (ReqDateOrig != ReqDate) {
                var timetemp

                if (probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "169" || probTypeDDL.value == "170" || probTypeDDL.value == "143" || probTypeDDL.value == "144") {
                    if (ReqDate !== datenow) {
                        $("#RequestTimetextBox").val(ReqTime2)
                        ReqTime = ReqTime2
                    }
                }

                if (ReqTime == "") {
                    ReqTime = ReqTime2
                    $("#RequestTime").val(ReqTime2)
                }
                if (ReqTime2 == "") {
                    ReqTime2 = ReqTime
                    $("#RequestTimeAllHours").val(ReqTime)
                }
                var AMPM = ReqTime.substring(ReqTime.length - 2, ReqTime.length);
                ReqTime = ReqTime.split(":")

                var AMPMTime = Timenow.substring(Timenow.length - 2, Timenow.length);
                Timenow = Timenow.split(":")

                var bNoonHour = false;
                if (Timenow[0] == 12 && AMPMTime == "PM") {
                    bNoonHour = true
                }

                var d1 = new Date(ReqDate);
                var d2 = new Date(datenow);
                var dayOfWeek = d1.getDay();

                if (ReqTime != "") {

                    minutes = ReqTime[1].substring(0, 2)
                }

                //if (d1 < d2) {
                //    swal("Request Date needs to be equal or greater than today.");
                //    $("#RequestDateTxt").focus();
                //    return false;
                //}
                //else

                if (Servers == "" && (probTypeDDL.value == "164" || probTypeDDL.value == "144")) {
                    $("#ValidateServers").css("display", "inline");
                    $("#cboServers_I").focus();
                    return false;
                }
                else if ((typeof ReqDate == 'undefined') || ReqDate == "") {
                    $("#ValidateRequestDate").css("display", "inline");
                    $("#RequestDateTxt").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "169" || probTypeDDL.value == "170" || probTypeDDL.value == "143" || probTypeDDL.value == "144") && (ReqTime[0] == "")) {
                    $("#ValidateRequestTime").css("display", "inline");
                    $("#RequestTimetextBox").focus();
                    $("#RequestTimeAllHourstextBox").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "153") && (FW == "")) {
                    $("#ValidateFireWall").css('display', 'inline');
                    $("#CloudList_0__FireWall_Info").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "153") && (Wan == "")) {
                    $("#ValidateWan").css('display', 'inline');
                    $("#CloudList_0__Wan_Info").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "153") && (VPN == "")) {
                    $("#ValidateVPN").css('display', 'inline');
                    $("#CloudList_0__VPN_Info").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "143" || probTypeDDL.value == "144" || probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "169" || probTypeDDL.value == "170") && (dayOfWeek != 0 && dayOfWeek != 6) &&
                    ((Timenow[0] > 3 || (Timenow[0] == 3 && Timenow[1].substring(0, 2) > 0)) && bNoonHour == false && AMPMTime == "PM") && ReqDate == datenow) {
                    swal("Please select another date or time. The deadline is 3 pm CST for same day request.");
                    $("#RequestTimetextBox").focus();
                    $("#RequestTimeAllHourstextBox").focus();
                    return false;
                }
                else if ((probTypeDDL.value == "162" || probTypeDDL.value == "164") && (dayOfWeek != 0 && dayOfWeek != 6) && (((ReqTime[0] < 6 && AMPM == "PM") || ((ReqTime[0] > 10 || (ReqTime[0] == 10 && minutes > 0)) && AMPM == "PM")) || AMPM == "AM")) {
                    swal("Time needs to be between 6:00 pm CST and 10:00 pm CST.");
                    $("#RequestTimetextBox").focus();
                    $("#RequestTimeAllHourstextBox").focus();
                    bOkayToProceed = false;
                }
                else if ((probTypeDDL.value == "169" || probTypeDDL.value == "170") && (dayOfWeek != 0 && dayOfWeek != 6) &&
                    ((ReqTime[0] < 8 && AMPM == "AM") || ((ReqTime[0] > 3 || (ReqTime[0] == 3 && minutes > 0)) && AMPM == "PM"))) {
                    swal("Time needs to be between 8:00 am CST and 3:00 pm CST.");
                    $("#RequestTimetextBox").focus();
                    $("#RequestTimeAllHourstextBox").focus();
                    bOkayToProceed = false;
                }
                //else if ((probTypeDDL.value == "143" || probTypeDDL.value == "144") && (((ReqTime[0] > 5 || (ReqTime[0] == 5 && minutes > 0)) && AMPM == "AM") || ((ReqTime[0] == 12 || ReqTime[0] < 6) && AMPM == "PM"))) {
                //    swal("Time needs to be between 6:00 pm CST and 5:00 am CST.");
                //    $("#RequestTimetextBox").focus();
                //    $("#RequestTimeAllHourstextBox").focus();
                //    bOkayToProceed = false;
                //}
                //else if ((probTypeDDL.value == "162" || probTypeDDL.value == "164") && (dayOfWeek != 0 || dayOfWeek != 7) && (((ReqTime[0] > 5 || (ReqTime[0] == 5 && minutes > 0)) && AMPM == "AM") || ((ReqTime[0] == 12 || ReqTime[0] < 6) && AMPM == "PM"))) {
                //    swal("Time needs to be between 6:00 pm CST and 5:00 am CST.");
                //    $("#RequestTimetextBox").focus();
                //    $("#RequestTimeAllHourstextBox").focus();
                //    bOkayToProceed = false;
                //}
                //else if ((probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "143" || probTypeDDL.value == "144") && (((ReqTime[0] < 5) || (ReqTime[0] == 5 && minutes < 30)) && AMPM == "AM")) {
                //    swal("Time needs to be between 5:00 pm CST and 5:00 am CST.");
                //    $("#RequestTimetextBox").focus();
                //    $("#RequestTimeAllHourstextBox").focus();
                //    return false;
                //}
                //else if ((probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "143" || probTypeDDL.value == "144") && ((ReqTime[0] > 10 && ReqTime[0] < 12) || (ReqTime[0] == 10 && minutes > 0)) && AMPM == "PM") {
                //    swal("Time needs to be between 5:00 pm CST and 5:00 am CST.");
                //    $("#RequestTimetextBox").focus();
                //    $("#RequestTimeAllHourstextBox").focus();
                //    return false;
                //}
                else if (probTypeDDL.value == "141" && (Notes == "")) {
                    swal("Please input new public IP and site information in the Notes box.");
                    bOkayToProceed = false;
                    return false;
                }

                else {
                    if ((probTypeDDL.value == "162" || probTypeDDL.value == "164" || probTypeDDL.value == "169" || probTypeDDL.value == "170" || probTypeDDL.value == "143" || probTypeDDL.value == "144") && (((ReqTime[0] == 12) && AMPM == "AM"))) {
                        swal("Time needs to be between 5:00 pm CST and 5:00 am CST.");
                        $("#RequestTimetextBox").focus();
                        $("#RequestTimeAllHourstextBox").focus();
                        bOkayToProceed = false;
                        return false;
                    }
                }
            }
        }


        if (bOkayToProceed == true) {
            var escapeHTML = {
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                '"': '&quot;',
                "'": "%27"
            };

            var originalNotesStr = document.getElementById("Cust_Notes");
            var strippedNotesStr = originalNotesStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; });
            originalNotesStr.value = strippedNotesStr;

            var originalINotesStr = document.getElementById("Internal_Notes");
            var strippedINotesStr = originalINotesStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; })
            originalINotesStr.value = strippedINotesStr;

            //var originalUCIDNotesStr = document.getElementById("UcidNotes");
            //var strippedUCIDNotesStr = originalUCIDNotesStr.value.replace(/[&<>"']/g, function(str) { return escapeHTML[str]; })
            //originalUCIDNotesStr.value = strippedUCIDNotesStr;

            var originalTitleStr = document.getElementById("Title");
            var strippedTitleStr = originalTitleStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; })
            originalTitleStr.value = strippedTitleStr;

            var originalTitleMenuItemStr = document.getElementById("TitleMenuItem");
            if (originalTitleMenuItemStr != null) {
                var strippedTitleMenuItemStr = originalTitleMenuItemStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; })
                originalTitleMenuItemStr.value = strippedTitleMenuItemStr;
            }

            var originalRandDNotesStr = document.getElementById("RandDList_0__RandDNotes");
            var strippedRandDNotesStr = originalRandDNotesStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; })
            originalRandDNotesStr.value = strippedRandDNotesStr;

            var originalBillingNotesStr = document.getElementById("BillingList_0__BillingNotes");
            var strippedBillingNotesStr = originalBillingNotesStr.value.replace(/[&<>"']/g, function (str) { return escapeHTML[str]; })
            originalBillingNotesStr.value = strippedBillingNotesStr;

            var exIssueNumber = document.getElementById("RandDList_0__ExhibitsIssue");
            var adIssueNumber = document.getElementById("RandDList_0__AddressesIssue");
            var exIssueNumberOrig = document.getElementById("RandDList_0__ExhibitsIssueOrig");
            var adIssueNumberOrig = document.getElementById("RandDList_0__AddressesIssueOrig");
            if (@Model.RandDList(0).CallIssueCount == 1 && (exIssueNumber.value == "" || adIssueNumber.value == "")) {
                if (exIssueNumber.innerHTML == exIssueNumberOrig.value || adIssueNumber.innerHTML == adIssueNumberOrig.value) {
                @Model.RandDList(0).DeadIssue = false
                    document.getElementById('BtnSave').click();
                }
                else {
                    DeleteIssuePopup();
                }
            }
            else {
            @Model.RandDList(0).DeadIssue = false


                       document.getElementById('BtnSave').click();

            }
        }
    }

    function DeleteIssuePopup() {
        swal({
            title: "This issue does not exist on another call!",
            text: "Deleting the issue will cause the issue to be orphaned. <br/> Do you wish to mark the issue as a Dead Issue? <br/> Selecting no, will keep the issue on the call.",
            type: "warning",
            html: true,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
     function (isConfirm) {
         var deadIssue = document.getElementById("RandDList_0__DeadIssue");
         //alert(isConfirm);
         deadIssue.value = isConfirm;
         //alert(deadIssue.value);
         document.getElementById('BtnSave').click();
     });
    }

    function SaveRefreshAction() {
        var ValueSelect = @Model.SIID
       //alert(ValueSelect)
        $.ajax({
            url: "/Calls/CallActionPartial",

            type: "get",
            data: { "siid": ValueSelect, "callType": "Internal" }, //if you need to post Model data, use this
            success: function (sSiid) {
                keepAliveCallsLayout();
                //console.log("Refresh")
                $("#DivRefresh").html(sSiid);
            }
        });
    }

    function SaveRefreshFileGrid() {
        var ValueSelect = @Model.SIID
       //alert(ValueSelect)
        $.ajax({
                url: "/Calls/CallFilesPartial",

            type: "get",
            data: { "siid": ValueSelect }, //if you need to post Model data, use this
            success: function (sSiid) {
                keepAliveCallsLayout();
                //console.log("Refresh")
                $("#DivRefreshFiles").html(sSiid);
            }
        });
    }

    function DeleteRefreshFiles(id, siid) {
       var siid= @Model.SIID

           swal({
               title: "Are you sure you want to delete this file?",
               type: "warning",
               showCancelButton: true,
               confirmButtonColor: "#DD6B55",
               confirmButtonText: "Yes",
               cancelButtonText: "No",
               closeOnConfirm: true,
               closeOnCancel: true
           },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: "/Calls/FileDelete",

                    type: "get",
                    data: { "id": id, "siid":siid }, //if you need to post Model data, use this
                    success: function (model) {
                        $("#DivRefreshFiles").html(model);
                    }
                });
                return false;
            } else {

                return true;
            }
        });
    }

    function SaveRefreshFile() {
        console.log("SaveRefreshFile")
        var fd = new FormData();
        var siid= @Model.SIID;
        var ucid=@Model.UCID;
        var uid=@Model.UID;

        var filesize = document.getElementById('fileInput').files[0].size / 1024 / 1024;

        if (filesize > 30) {
            swal({
                title: "The file that is attached is too big! Please attach a different file.",
                text: "Max size is 30 MB",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                closeOnConfirm: true,
            });
            return false;
        }
        else {
            fd.append("File", document.getElementById('fileInput').files[0]);
            fd.append("sSiid", siid);
            fd.append("sUID", uid);
            fd.append("sUCID", ucid);

            $.ajax({
                type: 'POST',
                url: "/Calls/CallEditFileSave",
                data: fd,
                cache: false,
                contentType: false,
                processData: false,
                success: function (model) {

                    document.getElementById("fileInput").value = "";
                    $("#DivRefreshFiles").html(model);
                },
            });
        }
    }

    function ShowText(linkId, divId){
        var link = document.getElementById(linkId.id);
        var div = document.getElementById(divId.id);
        var moreLess = link.innerText;

        if (moreLess === "More >>")
        {
            link.innerText = "<< Less";
            div.style.display = "block";
        }
        else
        {
            link.innerText = "More >>";
            div.style.display = "none";
        }
    }

    function ShowPanel(btnPanel,contentPanel){
        var panel = document.getElementById(contentPanel.id);
        var button = document.getElementById(btnPanel.id);
        if (panel.style.display === "block") {
            panel.style.display = "none";
            button.className = "glyphicon glyphicon-chevron-right";
        } else {
            panel.style.display = "block";
            button.className = "glyphicon glyphicon-chevron-down";
        }
    }

    function SetProjectName(projectID, projectName) {
        var textProjectName = document.getElementById("projectName");
        var hiddenProjectID = document.getElementById("projectID");
        textProjectName.value = projectName;
        hiddenProjectID.value = projectID;
    }

    function SetCoderName(s,e) {
        var lblCoder = document.getElementById("codersLabel");
        var hdnCoders = document.getElementById("codersHidden");
        hdnCoders.value = "";
        lblCoder.innerText = "";
        for (var i = 0; i < s.GetItemCount(); i++) {
            var item = s.GetItem(i);
            if(item.selected) {
                lblCoder.innerText += ", " + item.text;
                hdnCoders.value += item.value + ",";
            }
        }
        lblCoder.innerText = lblCoder.innerText.substring(2, lblCoder.innerText.length + 2)
        hdnCoders.value = hdnCoders.value.substring(0, hdnCoders.value.length - 1)
    }

    function SetTesterName(s,e) {
        var lblTester = document.getElementById("testersLabel");
        var hdnTesters = document.getElementById("testersHidden");
        hdnTesters.value = "";
        lblTester.innerText = "";
        for (var i = 0; i < s.GetItemCount(); i++) {
            var item = s.GetItem(i);
            if (item.selected) {
                lblTester.innerText += ", " + item.text;
                hdnTesters.value += item.value + ",";
            }
        }
        lblTester.innerText = lblTester.innerText.substring(2, lblTester.innerText.length + 2)
        hdnTesters.value = hdnTesters.value.substring(0, hdnTesters.value.length - 1)
    }

    function GoToQuote() {
        var panel = document.getElementById("randdInfo");
        var button = document.getElementById("btnRandDInfo");
        if (panel.style.display === "none") {
            panel.style.display = "block";
            button.className = "glyphicon glyphicon-chevron-down";
        }
        document.getElementById("startDateText").scrollIntoView();
    }

    function OnRowClick(s, e, url) {
        var key = s.GetRowKey(e.visibleIndex);

        var destUrl = url + "/" + key;

        window.open(destUrl);
    }

    $(document).on("change", "#MASModuleList", function (e) {
        var ddlSelectionID = document.getElementById("MASModuleList");
        var txtSelectionID = document.getElementById("SelectionID");

        if(ddlSelectionID.value == "") {
            txtSelectionID.value = "0";
        }
        else {
            txtSelectionID.value = ddlSelectionID.value;
        }
    });

    $(document).on("change", "#SelectionID", function (e) {
        var ddlSelectionID = document.getElementById("MASModuleList");
        var txtSelectionID = document.getElementById("SelectionID");

        if(txtSelectionID.value == "" || txtSelectionID.value == "0") {
            txtSelectionID.value = "0";
            ddlSelectionID.value = "";
        }
        else {
            ddlSelectionID.value = txtSelectionID.value;
        }
    });

    $(document).on("change", "#MASHeaderList", function (e) {
        var ddlSequence = document.getElementById("MASHeaderList");
        var txtSequence = document.getElementById("Sequence");

        if(ddlSequence.value == "") {
            txtSequence.value = "0";
        }
        else {
            txtSequence.value = ddlSequence.value;
        }
    });

    $(document).on("change", "#Sequence", function (e) {
        var ddlSequence = document.getElementById("MASHeaderList");
        var txtSequence = document.getElementById("Sequence");

        if(txtSequence.value == "" || txtSequence.value == "0") {
            txtSequence.value = "0";
            ddlSequence.value = "";
        }
        else {
            ddlSequence.value = txtSequence.value;
        }
    });

    function SelectedMenu(s, e) {
        var MenuIDSelect = s.GetSelectedItem().value
        var menuID = document.getElementById("RandDList_0__MenuID");

        menuID.value = MenuIDSelect
    }

    function CloseGridLookupCoders(s, e) {
        cboCoders.HideDropDown();
    }

    function OnEndCallbackCoders(s, e) {
        cboCoders.GetGridView().SetFocusedRowIndex(-1);
    }

    function CloseGridLookupTesters(selectedValues) {
        cboTesters.HideDropDown();
    }

    function OnEndCallbackTesters(s, e) {
        cboTesters.GetGridView().SetFocusedRowIndex(-1);
    }


    function CloseGridLookupServers(s, e) {
        cboServers.HideDropDown();

        cboServers.GetGridView().GetSelectedFieldValues("CSTDesc", GotSelectedValues);

    }

    function OpenIssue(issueID) {
        var fd = new FormData();

        fd.append("issueID", issueID);

        $.ajax({
            type: 'POST',
            url: "/Calls/EditSWIssue",
            data: fd,
            cache: false,
            contentType: false,
            processData: false,
            success: function (model) {
                if (model != "") {
                    swal(model);
                }
            },
        });
    }

    function AddIssue(siid, title, description, menuItemID, verID) {
        var newIssueTitle = document.getElementById("Title");
        var newIssueTitleNoSpaces = newIssueTitle.value.replace(/\s/g, '');
        newIssueTitleNoSpaces = newIssueTitleNoSpaces.replace('.', '');

        var menuID = GSSMenuItemsList.GetValue();
        //var newIssueTitleNoSpaces = title.replace(/\s/g, '');
        //newIssueTitleNoSpaces = newIssueTitleNoSpaces.replace('.', '');

        if (newIssueTitleNoSpaces.length < 20) {
            swal({
                title: "Title needs to be at least 20 characters long to add an issue!",
            })
        }
        else if (menuID == "" || menuID == "0" || menuID == null) {
            swal({
                title: "Menu Item is required to add an issue!",
            })
        }
        else {
            if (newIssueTitle.value != title) {
                title = newIssueTitle.value
            }
            if (menuID != menuItemID) {
                menuItemID = menuID
            }

            var fd = new FormData();

            fd.append("siid", siid);
            fd.append("title", title);
            fd.append("description", description);
            fd.append("menuItemID", menuItemID);
            fd.append("verID", verID);

            $.ajax({
                type: 'POST',
                url: "/Calls/AddSWIssue",
                data: fd,
                cache: false,
                contentType: false,
                processData: false,
                success: function (model) {
                    if (model == "There was error. Please try again or contact the Service Web Admin.") {
                        swal(model);
                    }
                    else {
                        linkIssueMaint = document.getElementById('linkIssueMaint');
                        linkIssueMaint.href = "/Calls/EditSWIssue/?issueID=" + model
                        linkIssueMaint.click();
                        setTimeout(function () {
                            location.reload();
                        }, 5000);
                    }
                },
            });
        }
    }

    function IssueCleanup(siID) {
        var fd = new FormData();

        fd.append("siID", siID);
        fd.append("issueID", 0);
        fd.append("inNewIssueMaint", false);

        $.ajax({
            type: 'POST',
            url: "/Calls/RemoveSWIssue",
            data: fd,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                var empSave = response;
                if (empSave == 'Success') {
                    swal({
                        title: "Issue Removed From Call!",
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "OK",
                        closeOnConfirm: true,
                        html: true,
                    },
                    function (isConfirm) {
                        location.reload();
                    });
                }
                else if (empSave == 'Fail') {
                    swal({
                        title: "ERROR Removing Issue From Call!",
                        text: "Please try again or contact your Service Web Admin.",
                        type: "error",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "OK",
                        closeOnConfirm: true,
                        html: true,
                    });
                }
            }
        });
    }

    function RemoveIssue(siID, issueID, inNewIssueMaint) {
        var fd = new FormData();

        fd.append("siID", siID);
        fd.append("issueID", issueID);
        fd.append("inNewIssueMaint", inNewIssueMaint);

        $.ajax({
            type: 'POST',
            url: "/Calls/RemoveSWIssue",
            data: fd,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                var empSave = response;
                if (empSave == 'Success') {
                    swal({
                        title: "Issue Removed From Call!",
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "OK",
                        closeOnConfirm: true,
                        html: true,
                    },
                        function (isConfirm) {
                            location.reload();
                        });
                }
                else if (empSave == 'Fail') {
                    swal({
                        title: "ERROR Removing Issue From Call!",
                        text: "Please try again or contact your Service Web Admin.",
                        type: "error",
                        showCancelButton: false,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "OK",
                        closeOnConfirm: true,
                        html: true,
                    });
                }
            }
        });
    }

    function closeWindowChangeContactName(ctl, event) {
        swal({
            title: "Are you sure you want to cancel?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                contactNameChange.Hide();
                return false;
            } else {
                contactNameChange.Show();
                return true;
            }
        });
    }


    $(function () {
        $("#Qid").change(function () {
            var qID = document.getElementById("Qid");
            var previousQID = document.getElementById("previousQID");



            if (previousQID.value == "0" || previousQID.value == "532" || previousQID.value == "542") {
                // Will check if transferring to a Personal Queue when coming from Tier-1, Tier-1 Suspense, or Tier-2 and look at the Queue Max for the Employee
                $.ajax({
                    type: 'POST',
                    url: "/Calls/GetQueueTransferredToCallIsPersonal",
                    data: { "qID": qID.value },
                    success: function (response) {
                        var empSave = response;
                        if (empSave == 'SuccessQueue') {
                            //Will check Personal Queue Count and compare it to the Employees Queue Max
                            $.ajax({
                                type: 'POST',
                                url: "/Calls/CheckQueueCallMax",
                                data: { "bTier2": false, "qID": qID.value },
                                success: function (response) {
                                    var empSave = response;
                                    if (empSave == 'Success') {
                                        return true;
                                    }
                                    else if (empSave == 'Fail') {
                                        swal({
                                            title: "QUEUE MAX!",
                                            text: "You are currently at your queue's maximum limit. Please contact your manager if you need to pull this call or manage your queue before getting a new call.",
                                            type: "error",
                                            showCancelButton: false,
                                            confirmButtonColor: "#DD6B55",
                                            confirmButtonText: "OK",
                                            closeOnConfirm: true,
                                            html: true,
                                        },
                                        function (isConfirm) {
                                            qID.value = previousQID.value;
                                        });
                                        return false;
                                    }
                                    //else if (empSave == 'FailOtherEmp') {
                                    //    swal({
                                    //        title: "QUEUE MAX!",
                                    //        text: "The queue that is selected is currently at its maximum limit. Please contact their manager if you need to transfer this.",
                                    //        type: "error",
                                    //        showCancelButton: false,
                                    //        confirmButtonColor: "#DD6B55",
                                    //        confirmButtonText: "OK",
                                    //        closeOnConfirm: true,
                                    //        html: true,
                                    //    },
                                    //        function (isConfirm) {
                                    //            qID.value = previousQID.value;
                                    //    });
                                    //    return false;
                                    //}
                                }
                            });
                        }
                        else if (empSave == 'FailQueue') {
                            //This not a personal queue that call can be transferred.
                            return true;
                        }
                    }
                });
            }
            var Incident = $("#previoIncidentID").val()
            var ExhibitIncident = $("#ExhibitsIncident").val()

            if (qID.value == "63" && (Incident == null && ExhibitIncident == null )) {

                swal("In order to transfer this call to R&D it requires a new incident or an existing incident to be assigned. Please add an incident to this call and try again.")

               $('#Qid').val(previousQID.value);


            }

            if (qID.value == "63" ) {

               $('#IncidentStatus').val("2");


            }

        });
    })

    function SendContactEmail(siID) {
        var actionRowCount = document.getElementById("actionRowCount");
        var tlGrp = document.getElementById("tlGrp");
        var emailContact = document.getElementById('emailContact');

        if (actionRowCount.value <= 4 && (tlGrp.value == 35 || tlGrp.value == 56 || tlGrp.value == 57 || tlGrp.value == 58)) {
            var fd = new FormData();

            fd.append("siID", siID);

            $.ajax({
                type: 'POST',
                url: "/Calls/CustomTier1CallEmail",
                data: fd,
                cache: false,
                contentType: false,
                processData: false,
                success: function (model) {
                    emailContact.href = model;
                    emailContact.click();
                },
            });
        }
        else {
            emailContact.click();
        }
    }

    function OnRefNoClick(txtCopy) {
        var textArea = document.createElement("textarea");
        textArea.value = txtCopy;

        // Avoid scrolling to bottom
        textArea.style.top = "0";
        textArea.style.left = "0";
        textArea.style.position = "fixed";

        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();

        try {
            var successful = document.execCommand('copy');
            var msg = successful ? 'successful' : 'unsuccessful';
            //console.log('Fallback: Copying text command was ' + msg);

            if (msg == "successful") {
                //swal({
                //    title: "REFERENCE NO COPIED",
                //    timer: 3000,
                //})
                toastNotify.SetContentHtml("REFERENCE NO COPIED");
                //toastNotify.Show();
                toastNotify.ShowAtElementByID("wrapper");
            }
            else {
                swal({
                    title: "ERROR COPYING!",
                    text: "Please try again or contact your Service Web Admin.",
                })
            }
        } catch (err) {
            swal({
                title: "ERROR COPYING!",
                text: "Please try again or contact your Service Web Admin.",
            })
        }

        document.body.removeChild(textArea);
    }




    $(document).on("change", "#CategoryId", function (e) {

        var CategoryId = document.getElementById("CategoryId");

        ///*  ' var */CategoryId=  $("#CategoryId").val($(this).find("option:selected").text());

        $.ajax({
            type: 'POST',
            url: "/Calls/GetProblemTypeCloud",
            data: { "Id": CategoryId.value, "bInternal": true },
            dataType: 'json',
            success: function (result) {


                $("#CloudReqDropDown").empty()

                $("#CloudReqDropDown").append('<option value="">Select </option>');
                var list = result.Data
                $.each(list, function (i, ProbType) {
                    $("#CloudReqDropDown").append('<option value="' + ProbType.Value + '">' + ProbType.Text + '</option>');

                });

            },
            error: function (ex) {
                alert('Failed to retrieve Loactions.' + ex);
            }
        });
    });

    //function OnChangedServer(s, e) {
    //    SetVisibilityserver(s);
    //}
    //function SetVisibilityserver(s) {
    //    cboServers.GetGridView().GetSelectedFieldValues("CSTDesc", GotSelectedValues);
    //}

    function OnChangedServer(s, e) {
        cboServers.GetGridView().GetSelectedFieldValues("CSTID", GetSelectedFieldValuesCallbackServers);
    }

    function GetSelectedFieldValuesCallbackServers(selValues) {
        var hdnServers = document.getElementById("Serversid");
        hdnServers.value = "";
        for (var i = 0; i < selValues.length; i++) {
            hdnServers.value += selValues[i] + ",";
        }
        hdnServers.value = hdnServers.value.substring(0, hdnServers.value.length - 1)
        idRequestnew = hdnServers.value
    }


    $(document).on("change", "#ProblemID", function (e) {
        var IdReq = document.getElementById("ProblemID");


        var url = "/Calls/GetProblemCategory?ProbId=" + IdReq.value;

        $.ajax({
            type: 'POST',
            url: url,

            dataType: 'json',

            success: function (data) {
                var panel = document.getElementById("callCloud");
                var header = document.getElementById("headingCallCloud");
                if (data == "Cloud") {
                    if (panel.style.display === "none") {
                        panel.style.display = "block";
                        header.style.display = "block";
                    }
                }
                else {
                    panel.style.display = "none";
                    header.style.display = "none";
                }

            }
        });

        $("#RequestTimeAllHourstextBox").val()
        $("#RequestTimetextBox").val()


        $("#RequestTypeDesc").val($(this).find("option:selected").text());

        //Hotfixes
        if (IdReq.value == "162" || IdReq.value == "169") {

            $('#DivHotFixes').show();

        } else {

            $('#DivHotFixes').hide();


        }


        if (IdReq.value == "162" || IdReq.value == "164" || IdReq.value == "169" || IdReq.value == "170" || IdReq.value == "143" || IdReq.value == "144") {

            $('#DivTime').show();

        } else {


            $('#DivTime').hide();

        }
        //164 Reboot Server=144 Reboot Server(s) (Today 8am-3pm)

        if (IdReq.value == "164" || IdReq.value == "144" || IdReq.value == "170") {

            //$('#DivReboot').show();

            $('#DivServers').show();

        } else {
            //'Reboot

            //$('#DivReboot').hide();

            $('#DivServers').hide();
        }

        if (IdReq.value == "162" || IdReq.value == "164" || IdReq.value == "169" || IdReq.value == "170" || IdReq.value == "143" || IdReq.value == "144") {

            var datenow = $("#DateNow").val()
            var ReqDate = $("#RequestDateTxt").val()

            if (IdReq.value == "143" || IdReq.value == "144" || IdReq.value == "169" || IdReq.value == "170") {

                $('#DivReboot').hide();
                $('#DivHotFixes').hide();
                $('#RequestTime').val(datenow)
                $('#datetimeRequest').datetimepicker({
                    format: 'LT',
                    minDate: moment(),
                    disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                });
            }

            if (datenow == ReqDate) {

                if (IdReq.value == "164") {
                    $('#datetimeRequest').datetimepicker({
                        format: 'LT',
                        minDate: moment()

                    });

                }
                else if (IdReq.value == "169" || IdReq.value == "170") {
                    $('#datetimeRequest').datetimepicker({
                        format: 'LT',
                        disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                    });
                    $('#datetimeRequest2').datetimepicker({
                        format: 'LT',
                        disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                    });
                }
                else {
                    $('#datetimeRequest').datetimepicker({
                        format: 'LT',
                        minDate: moment(),
                        disabledHours: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16']

                    });

                }



                // var ReqTime = $("#RequestTimeAllHours").val()

                //// if (ReqTime !== "") {
                //     if (ReqTime !== "[object HTMLDivElement]") {
                //         $("#RequestTime").val(ReqTime)
                //     }
                //// }
                $("#RequestTimeAllHourstextBox").val();
                $("#RequestTimeAllHours").val();
                $("#RequestTimetextBox").val();
                $('#DivTimePastTime').hide();
                $('#DivTimeNoPastTime').show();


            }
            else {

                $('#datetimeRequest').datetimepicker({
                    format: 'LT'
                });

                $('#datetimeRequest2').datetimepicker({
                    format: 'LT'
                }).on('dp.change', function (e) {

                    //$("#RequestTime").val(this)
                    //$("#RequestTime").val($("#datetimeRequest2").val())
                });

                if (IdReq.value == "169" || IdReq.value == "170") {
                    $('#datetimeRequest2').datetimepicker({
                        format: 'LT',
                        disabledHours: ['1', '2', '3', '4', '5', '6', '7', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                    });
                }

                var ReqTime = $("#RequestTimetextBox").val()
                if (ReqTime !== "") {

                    $("#RequestTimeAllHourstextBox").val(ReqTime);
                }

                $('#DivTimePastTime').show();
                $('#DivTimeNoPastTime').hide();


            }


        }





        if (IdReq.value == "153") { /*'Add VPN Tunnel'*/

            $('#DivVPN').show();

        } else {

            $('#DivVPN').hide();
        }



    });

    function SetNameServers(uid, custName, custNo) {


        var url = "/Cloud/Get_ServersByUID?uid=" + uid;


        $.ajax({
            type: 'POST',
            url: url,

            dataType: 'json',

            success: function (data) {

                $('#DivServersUpdate').load('/cloud/MultiSelectPartial');



            },
            error: function (ex) {
                alert('Failed to retrieve customers.' + ex);
            }
        });

        customerSearchModal.Hide();
    }


    $(document).on("change", "#CallTypeID", function (e) {

        var CallTypeID = document.getElementById("CallTypeID");
        var siid = @Model.SIID;
        var IsCloudRequest = document.getElementById("IsCloudRequest");
        var bInternational = document.getElementById("bInternational");

        var probID = $("#hdnProbID_Orig").val();
        var currentCallType = $('#currentCallType').val();
        $('#currentCallType').val(CallTypeID.value);

        if (CallTypeID.value == "49" || CallTypeID.value == "37" || currentCallType == "49" || currentCallType == "37") {
            $.ajax({
                type: 'POST',
                url: "/Calls/GetProblemTypeCall",
                data: { "Id": CallTypeID.value, "bInternal": true, "siid": siid, "bInternational": bInternational.value},
                dataType: 'json',
                success: function (result) {
                    $("#ProblemID").empty()

                    $("#ProblemID").append('<option value="">Select </option>');
                    var list = result.Data
                    $.each(list, function (i, ProbType) {
                        $("#ProblemID").append('<option value="' + ProbType.Value + '">' + ProbType.Text + '</option>');

                    });

                    var panel = document.getElementById("callCloud");
                    var header = document.getElementById("headingCallCloud");

                    if (CallTypeID.value == "37" || CallTypeID.value == "49") {
                        IsCloudRequest.value = true;

                        if (panel.style.display === "none") {
                            panel.style.display = "block";
                            header.style.display = "block";
                        }

                        var IdReq = document.getElementById("ProblemID");

                        $("#RequestTimeAllHourstextBox").val()
                        $("#RequestTimetextBox").val()


                        $("#RequestTypeDesc").val($(this).find("option:selected").text());

                        //Hotfixes
                        if (IdReq.value == "162") {

                            $('#DivHotFixes').show();

                        } else {

                            $('#DivHotFixes').hide();


                        }


                        if (IdReq.value == "162" || IdReq.value == "164" || IdReq.value == "169" || IdReq.value == "170" || IdReq.value == "143" || IdReq.value == "144") {

                            $('#DivTime').show();

                        } else {


                            $('#DivTime').hide();

                        }
                        //164 Reboot Server=144 Reboot Server(s) (Today 8am-3pm)

                        if (IdReq.value == "164" || IdReq.value == "144") {

                            //$('#DivReboot').show();

                            $('#DivServers').show();

                        } else {
                            //'Reboot

                            //$('#DivReboot').hide();

                            $('#DivServers').hide();
                        }
                        ////'Reboot today'
                        //if (IdReq.value == "144") {


                        //    $('#DivServers').show();

                        //} else {


                        //    $('#DivServers').hide();
                        //}


                        if (IdReq.value == "143" || IdReq.value == "144") {

                            var datenow = $("#DateNow").val()


                            datenow = datenow.replace(".", "/")
                            datenow = datenow.replace(".", "/")

                            var datenowsplit = datenow.split('/')



                            if (datenowsplit[0].length == 1) {
                                var month
                                var day = '0' + datenowsplit[0]
                                if (datenowsplit[1].length == 1) {
                                    var month = '0' + datenowsplit[1]
                                }
                                datenow = day + '/' + month + '/' + datenowsplit[2]

                            }


                            //$('#DivReboot').hide();
                            //$('#DivHotFixes').hide();
                            $('#RequestDateTxt').val(datenow)

                            //$('#RequestDateTxt').attr('readonly', true);
                            $('#datetimeRequest').datetimepicker({
                                format: 'LT',
                                minDate: moment()
                                ,
                                disabledHours: ['1', '2', '3', '4', '5', '6', '7', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24']

                            });
                        }
                        else {

                            $('#RequestDateTxt').val("")
                            $('#RequestDateTxt').attr('readonly', false);
                            $('#datetimeRequest').val("")
                            $('#datetimeRequest').datetimepicker({
                                format: 'LT',
                                minDate: moment()

                            });
                        }
                        if (IdReq.value == "153") { /*'Add VPN Tunnel'*/

                            $('#DivVPN').show();

                        } else {

                            $('#DivVPN').hide();
                        }
                    }
                    else {
                        IsCloudRequest.value = false;
                        panel.style.display = "none";
                        header.style.display = "none";

                        $("#ProblemID").val(probID);
                    }
                },
                error: function (ex) {
                    alert('Failed to retrieve Loactions.' + ex);
                }
            });
        }
    });

        function ShowIncident() {

              var menuID = GSSMenuItemsList.GetValue();

             if (menuID == "" || menuID == "0" || menuID == null) {
                swal({
                    title: "Menu Item is required to add an incident.",
                })}
                 else {
                    $("#IncidentSection").show();
                      $("#IncidentStatus").focus();
        }
    }


    function IncidentCleanup(SIID, sWheretoUpdate) {
            var fd = new FormData();

        fd.append("iSIID", SIID);
        fd.append("sWheretoUpdate", sWheretoUpdate);


            $.ajax({
                type: 'POST',
                url: "/Calls/RemoveIncident",
                data: fd,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    var empSave = response;
                    if (empSave == 'Success') {
                        swal({
                            title: "Incident Removed From Call!",
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#DD6B55",
                            confirmButtonText: "OK",
                            closeOnConfirm: true,
                            html: true,
                        },
                        function (isConfirm) {
                            location.reload();
                        });
                    }
                    else if (empSave == 'Fail') {
                        swal({
                            title: "ERROR Removing Incident From Call!",
                            text: "Please try again or contact your Service Web Admin.",
                            type: "error",
                            showCancelButton: false,
                            confirmButtonColor: "#DD6B55",
                            confirmButtonText: "OK",
                            closeOnConfirm: true,
                            html: true,
                        });
                    }
                }
            });
        }

         $(document).ready(function () {

            $('#IncidentStatus').change(function (e) {

                    var status = $('#IncidentStatus').val();
                    if (status == 4) {//Denied status

                        $('#DivRejection').show();



                    }
                    else {


                        $('#DivRejection').hide();
                    }



                }).change();




        });
     $(document).ready(function () {

           $('#Reject_Reason').change(function (e) {

                    var Reject = $('#Reject_Reason').val();
                    if (Reject == 1) {//already reported denid status

                        $('#DivIncidentNumber').show();



                    }
                    else {
                        $('#Duplicate_ofIncidentId').val("");

                      $('#DivIncidentNumber').hide();
                    }



                }).change();

        });
</script>


<style type="text/css">
    .bold-text {
        font-weight: bold !important;
    }

    .normal-text {
        font-weight: normal !important;
    }

    .largeImg {
        width: 100%;
        height: auto;
        display: block;
    }
</style>

@If ViewData("bCustomerITAR") Then


    @Using (Html.BeginForm("CallEditSaveInternal", "Calls", FormMethod.Post, New With {.enctype = "multipart/form-data", .id = "frmCall"}))
        @<div class="container-fluid">
            @Html.ValidationSummary(True)
            <div class="row">
                <div class="col-md-6">
                    <h1 class="TitleSectionsName">Service Response</h1>
                </div>
                <div class="col-md-6">
                    <div class="back-link-home">
                        @Code
                            'If QueueID is 0 or 523 then it will go to the Service Tier Queues if not, will go to Personal Queue
                            If Session("QueueID") IsNot Nothing Then
                                If Session("QueueID") = "0" Then
                                    @<a href="@Url.Action("CallSearch", "Calls")">Back</a>
                                Else
                                    @<a href="@Url.Action("Index", "ServiceTier", New With {.id = Session("QueueID")})">Back</a>
                                End If
                            Else
                                @<a href="@Url.Action("Index", "PersonalQueue")">Back</a>
                            End If
                        End Code
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showNotesDisplay = "none"
                        If ViewBag.CustomerCallNotes IsNot Nothing AndAlso ViewBag.CustomerCallNotes <> "" Then
                            showNotesDisplay = "block"
                        End If
                    End Code
                    <div class="alert alert-info" role="alert" style="font-size:medium; padding:5px !important; margin-bottom:5px !important;display:@showNotesDisplay;" id="headingNotesInfo">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Customer Notes</span>
                        @*Customer Notes:*@ <span id="customerNotes">Special Notes: @ViewBag.CustomerCallNotes</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showNotesHighPrior = "none"
                        If ViewBag.CustomerHighPriorityCalls IsNot Nothing AndAlso ViewBag.CustomerHighPriorityCalls <> "" Then
                            showNotesHighPrior = "block"
                        End If
                    End Code
                    <div class="alert alert-danger" role="alert" style="font-size:medium; padding:5px !important; margin-bottom:5px !important;display:@showNotesHighPrior;" id="headingHighPriorInfo">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">At Risk Customer</span>
                        At Risk Customer Reason(s):
                        <div id="highPriorNotes" style="white-space: pre-line">@ViewBag.CustomerHighPriorityCalls.ToString.Replace("<br/>", Environment.NewLine)</div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <ul class="tooltip-end">
                        <li>
                            @Html.LabelFor(Function(model) model.Title, New With {.class = "TitleGrayOblique"})
                        </li>
                        <li>
                            <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.Title, String.Empty, New With {.style = "color:red;!important"})
                        </li>
                    </ul>
                    @Html.TextBoxFor(Function(model) model.Title, New With {.class = "ControlsFormat ControlwidthExtraPlus"})
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    @Html.LabelFor(Function(model) model.RefNo, "Reference No", New With {.class = "TitleGrayOblique"})
                    @Html.DisplayFor(Function(model) model.RefNo, New With {.class = "TitleBlack ControlwidthEdit  ControlsFormat backgroundgray"})
                    @*&nbsp;&nbsp;<a href="javascript:GoToQuote()">Go To Quote Information</a>*@
                    <a class="btn btn-default btn-xs" href="javascript:OnRefNoClick('@Model.RefNo')"><img title="Copy" src="/../Images/Calls/copy_16x16.png" /></a>
                </div>
                <div class="col-md-2">
                    @Code
                        If Model.SplitCallCount <> 0 Then
                            Dim splitCallLink As String = ""
                            If Model.Parent = Model.SIID Or Model.SplitCallMode = 3 Then
                                splitCallLink = "Split Calls List"
                            Else
                                splitCallLink = "Parent Call"
                            End If
                    End Code
                    <a href="javascript:void(0);" onclick="chilrenCallsModal.Show();">
                        @*Split Calls List*@
                        @splitCallLink
                    </a>
                    @Code End If End Code
                </div>
                <div class="col-md-2">
                    @Code If Model.ProjectCallCount <> 0 Then End Code
                    <a href="javascrpit:projectCallsModal.Show();">
                        Project Calls List
                    </a>
                    @Code End If End Code
                </div>
                <div class="col-md-2">
                    <a href='@Url.Action("CallSplitNew", "Calls", New With {.siid = Model.SIID})' target="_self">
                        Split Current Call
                    </a>
                </div>
                <div class="col-md-2">
                    <a href='@Url.Action("CallNew", "Calls", New With {.idMode = "3", .uid = Model.UID, .ucid = Model.UCID})' target="_blank">
                        New Call
                    </a>
                </div>
                <div class="col-md-1">

                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    @Code
                        Dim sBoldWeight = "normal-text"
                        Dim dateDifference = DateDiff(DateInterval.Day, ViewBag.LastUpdateVer, Date.Now.Date)
                        If dateDifference <= 14 And ViewBag.ActiveVersionID = Model.VerID Then
                            sBoldWeight = "bold-text"
                        End If
                    End Code

                    @Html.LabelFor(Function(model) model.CompanyName, "Customer Name", New With {.class = "TitleGrayOblique"})
                    <span class="@sBoldWeight">
                        @Html.DisplayFor(Function(model) model.CompanyName, New With {.class = "TitleBlack ControlwidthEdit  ControlsFormat backgroundgray"})
                    </span>
                    @If sBoldWeight = "bold-text" Then
                        @<a class="btn btn-default btn-xs" onclick="javascript: versionDateModal.Show();">
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" style="color:red;"></span>
                        </a>
                    End If
                    @Html.HiddenFor(Function(model) model.CompanyName)
                    @Html.HiddenFor(Function(model) model.RefNo)
                    @Html.HiddenFor(Function(model) model.GSS_CustNo)
                    <a class="btn btn-default btn-xs" href='@Url.Action("Index", "General", New With {.id = Model.UID})' target="_blank">
                        <span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span>
                    </a>
                    @Code
                        Model.StartTime = Date.Now
                    End Code
                    @Html.HiddenFor(Function(model) model.StartTime)
                    @*@Html.HiddenFor(Function(model) model.StartTime, New With {.value = DateTime.Now})*@
                    @Code
                        Dim compCode = ViewBag.CompanyCodeNoNotes 'Session("CompanyCodeNoNotes")
                        Dim comp As String = ""
                        For i = 0 To compCode.GetUpperBound(0)
                            comp += compCode(i) + ","
                        Next
                        If comp.Length > 0 Then
                            comp = comp.Substring(0, comp.Length - 1)
                        End If
                    End Code
                    <input type="hidden" id="companyCodeNoNotes" value="[@comp]" />
                </div>
                <div class="col-md-3">
                    <label>
                        @Html.CheckBoxFor(Function(model) model.CloudCustomer, New With {.disabled = "disabled"})
                        <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Cloud Customer</span>
                    </label>
                </div>
                <div class="col-md-3">
                    <label>
                        @Html.CheckBoxFor(Function(model) model.OnServiceHold, New With {.disabled = "disabled"})

                        @Code
                            Dim onServiceHoldColor = ""
                            If Model.OnServiceHold = True Then
                                onServiceHoldColor = "Red"
                            End If
                        End Code
                        <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important; color:@onServiceHoldColor;">&nbsp;On Service Hold</span>
                    </label>
                </div>
                <div class="col-md-3">
                    <label>
                        @Html.CheckBoxFor(Function(model) model.OnRetainer, New With {.disabled = "disabled"})
                        <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;On Retainer</span>
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    @Html.LabelFor(Function(model) model.BillToList(0).PM, "Project Manager", New With {.class = "TitleGrayOblique"})
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        <a href="mailto:@Model.BillToList(0).PMEmail?subject=@Model.Title.Replace("&", "%26") || GSRX-@Model.RefNo-GSRX">@Model.BillToList(0).PM</a>
                    </span>
                </div>
                <div class="col-md-3">
                    @Html.LabelFor(Function(model) model.BillToList(0).AR, "Customer Success Manager", New With {.class = "TitleGrayOblique"})
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        <a href="mailto:@Model.BillToList(0).AREmail?subject=@Model.Title.Replace("&", "%26") || GSRX-@Model.RefNo-GSRX">@Model.BillToList(0).AR</a>
                    </span>
                </div>
                <div class="col-lg-1 col-md-2">
                    <span class="TitleGrayOblique">
                        @Html.LabelFor(Function(model) model.LocID, "Location")
                    </span>
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        @Html.DisplayFor(Function(model) model.Loc_Desc)
                    </span>
                </div>
                <div class="col-md-1">
                    @Html.LabelFor(Function(model) model.PFCDesc, "Database", New With {.class = "TitleGrayOblique"})
                    @Html.DisplayFor(Function(model) model.PFCDesc, New With {.class = "TitleBlack ControlwidthEdit  ControlsFormat backgroundgray"})
                </div>
                @Code
                    If Model.VerID >= 45 Then
                        Dim sColor = "Black"
                        If ViewBag.CurrentCustBuildNo <> ViewBag.CurrentBuildNo Then
                            sColor = "red"
                        End If
                        @<div class="col-lg-1 col-md-2">
                            @Html.Label("HF Installed", New With {.class = "TitleGrayOblique"})
                            <span style="color:@sColor">@ViewBag.CurrentCustBuildNo</span>
                        </div>
                        @<div class="col-lg-1 col-md-2">
                            @Html.Label("HF Released", New With {.class = "TitleGrayOblique"})
                            <span>@ViewBag.CurrentBuildNo</span>
                        </div>
                    End If
                End Code
            </div>
            <div class="row">
                <div class="col-md-3">
                    <span class="TitleGrayOblique">
                        @Html.LabelFor(Function(model) model.ContactName)
                    </span>
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        @Html.DisplayFor(Function(model) model.ContactName) <a onclick="javascript: contactNameChange.Show()"> <img src="~/Images/Common/icon_edit.png" id="ImgPreEdit" width="10" height="10" /></a>
                    </span>
                </div>
                <div class="col-md-3">
                    <span class="TitleGrayOblique">
                        @Html.LabelFor(Function(model) model.ContactEmail, "Email")
                    </span>
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        @*<a href="mailto:@Model.ContactEmail?subject=@Model.Title.Replace("&", "%26") || GSRX-@Model.RefNo-GSRX">@Model.ContactEmail</a>*@
                        <a href="javascript: SendContactEmail(@Model.SIID)">@Model.ContactEmail</a>
                        <a id="emailContact" style="display: none;" href="mailto:@Model.ContactEmail?subject=@Model.Title.Replace("&", "%26") || GSRX-@Model.RefNo-GSRX">@Model.ContactEmail</a>
                    </span>
                </div>
                <div class="col-md-3">
                    <span class="TitleGrayOblique">
                        @Html.LabelFor(Function(model) model.Contact_Phone1, "Phone")
                    </span>
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        @If Session("Use_RingCentral") = True Then
                            @<a href="tel:@Model.Contact_Phone1">@Model.Contact_Phone1</a>
                        Else
                            @Html.DisplayFor(Function(model) model.Contact_Phone1)
                        End If
                        &nbsp;Ext.&nbsp;
                        @Html.DisplayFor(Function(model) model.Contact_Phone1Ext)
                        <a class="btn btn-default btn-xs" onclick="javascript: phoneExt1Modal.Show();">
                            <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                        </a>
                    </span>
                </div>
                <div class="col-md-3">
                    <span class="TitleGrayOblique">
                        @Html.LabelFor(Function(model) model.Contact_Phone2, "Alt Phone")
                    </span>
                    <span class="TitleBlack ControlwidthEdit  ControlsFormat backgroundgray">
                        @If Session("Use_RingCentral") = True Then
                            @<a href="tel:@Model.Contact_Phone2">@Model.Contact_Phone2</a>
                        Else
                            @Html.DisplayFor(Function(model) model.Contact_Phone2)
                        End If
                        &nbsp;Ext.&nbsp;
                        @Html.DisplayFor(Function(model) model.Contact_Phone2Ext)
                        <a class="btn btn-default btn-xs" onclick="javascript: phoneExt2Modal.Show();">
                            <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                        </a>
                    </span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="background-color:lemonchiffon; color:#238B68; font-weight:bold; text-align:center; padding:5px;">
                    Current Time for Customer: @Model.CurrentTime &nbsp;&nbsp;&nbsp;Can contact until: @Model.CentralTime &nbsp;&nbsp;&nbsp;Please Contact by: @Model.PreferredContact
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        If Model.UCID_Notes IsNot Nothing Then
                            @<span>Contact Notes: @Model.UCID_Notes</span>
                        End If
                    End Code
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showCallInfoDisplay = "block"
                        Dim showCallInfoButtonText = "glyphicon glyphicon-chevron-down"
                        If Session("ShowCallInfo") = "False" Then
                            showCallInfoDisplay = "none"
                            showCallInfoButtonText = "glyphicon glyphicon-chevron-right"
                        End If

                        Dim countIndex As Integer = Model.IndexCount
                    End Code
                    <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingCallInfo" onclick="javascript:ShowPanel(btnCallInfo,callInfo)">
                        <label>
                            <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                <span id="btnCallInfo" class="@showCallInfoButtonText" style="color:#428bca;"></span>
                                &nbsp;Call Information
                            </span>
                        </label>
                    </div>
                    <div class="panel-body" id="callInfo" style="display:@showCallInfoDisplay;">
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.ProblemTypeList, "Problem Type", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                        &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                        &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.ProblemTypeList, String.Empty, New With {.style = "color:red;!important"})
                                    </li>
                                </ul>
                                @Html.DropDownListFor(Function(model) model.ProblemID, New SelectList(Model.ProblemTypeList, "ProbID", "ProbDesc", Model.ProblemID), "Select Type", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True})
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.AllActionsList(countIndex).ActionID, "Action Type", New With {.class = "TitleGrayOblique"})
                                @If Model.CloseCall = True Then
                                    @Html.HiddenFor(Function(model) model.ActionID)
                                    @<span class="TitleBlack ControlwidthEdit ControlsFormat backgroundgray">Closed Call</span>
                                Else
                                    @Html.DropDownListFor(Function(model) model.ActionID, New SelectList(Model.ActionTypeList, "TypeID", "TypeDesc", Model.AllActionsList(countIndex).ActionID), New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                End If
                            </div>
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.AllActionsList(countIndex).CallTypeID, "Call Type", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                        &nbsp;&nbsp;<span style="color:red !important;"><span id="callTypeError"></span></span>
                                    </li>
                                </ul>
                                @Html.DropDownListFor(Function(model) model.CallTypeID, New SelectList(Model.CallTypeList, "CallTypeID", "CallTypeDesc", Model.AllActionsList(countIndex).CallTypeID), New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Code
                                    Dim callType = ViewBag.CallTypeNoTesting 'Session("CallTypeNoTesting")
                                    Dim type As String = ""
                                    For i = 0 To callType.GetUpperBound(0)
                                        type += callType(i) + ","
                                    Next
                                    If type.Length > 0 Then
                                        type = type.Substring(0, type.Length - 1)
                                    End If
                                End Code
                                <input type="hidden" id="callTypeNoTesting" value="[@type]" />
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.Priority, "Priority", New With {.class = "TitleGrayOblique"})
                                @Code
                                    If Session("bAdmin") = True Or Session("bSuper") = True Or Session("bTeamLead") = True Or Session("iDeptID") = "1" Then
                                        @Html.DropDownListFor(Function(model) model.Priority, New SelectList(Model.PriorityList, "Value", "Text", Model.Priority), New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                    Else
                                        @Html.DisplayFor(Function(model) model.sProrityDesc, New With {.class = "TitleGrayOblique"})
                                        @Html.HiddenFor(Function(model) model.Priority)
                                    End If
                                End Code
                            </div>
                            <div class="col-md-1">
                                <label style="cursor:pointer;">
                                    @Html.CheckBoxFor(Function(model) model.System_Down)
                                    <span Class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;System Down</span>
                                </label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.Qid, "Queue", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                        &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.Qid, String.Empty, New With {.style = "color:red;!important"})
                                        <span style="color:red !important;"><span id="queueError"></span></span>
                                    </li>
                                </ul>
                                @Html.DropDownListFor(Function(model) model.Qid, New SelectList(Model.QueueList, "QueueListID", "QueueListDesc", "532"), "Select Type", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True})
                                <input type="hidden" id="previousQID" value="@Model.Qid" />
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.DueDate, "Due Date", New With {.class = "TitleGrayOblique"})
                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker2'>
                                        <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="dateDueText" value="@Model.DueDate" />
                                        @Html.HiddenFor(Function(model) model.DueDate)
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Code
                                    Dim VersionDefault As Integer
                                    Dim CurrentVersion As String = ""
                                    Dim showCallVersion As Boolean = True
                                    Dim cart = Session("GSSVersionSelection")
                                    Dim divShow As String = "block"
                                    For Each row In cart
                                        If row.Active = True Then
                                            VersionDefault = row.VerId
                                            CurrentVersion = row.GSVersion
                                            'If row.VerId = Model.Call_Ver Then
                                            '    divShow = "hidden"
                                            'End If
                                            Exit For
                                        End If
                                    Next
                                End Code
                                GSS Current Version
                                <span class="@sBoldWeight">
                                    @Html.DisplayFor(Function(model) CurrentVersion)
                                </span>
                                @If sBoldWeight = "bold-text" Then
                                    @<a class="btn btn-default btn-xs" onclick="javascript: versionDateModal.Show();">
                                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" style="color:red;"></span>
                                    </a>
                                End If
                                <br /><br />
                                <span style="visibility:@divShow">
                                    GSS Call Version
                                    @Html.DisplayFor(Function(model) model.GS_Version)
                                </span>
                                @Html.HiddenFor(Function(model) model.GS_Version_Supported)
                                @Code
                                    Dim randdQueue = Session("QueueLists")
                                    Dim randd As String = ""
                                    For Each row In randdQueue
                                        If row.RDQueue = True Then
                                            randd += row.QueueListID + ","
                                        End If
                                    Next
                                    If randd.Length > 0 Then
                                        randd = randd.Substring(0, randd.Length - 1)
                                    End If
                                End Code
                                <input type="hidden" id="randdQueue" value="[@randd]" />
                                @Code
                                    Dim serviceQueue = Session("QueueLists")
                                    Dim service As String = ""
                                    For Each row In serviceQueue
                                        If row.SQueue = True Then
                                            service += row.QueueListID + ","
                                        End If
                                    Next
                                    If service.Length > 0 Then
                                        service = service.Substring(0, service.Length - 1)
                                    End If
                                End Code
                                <input type="hidden" id="serviceQueue" value="[@service]" />
                                @Code
                                    Dim quoteQueue = Session("QueueLists")
                                    Dim quote As String = ""
                                    For Each row In quoteQueue
                                        If row.QueueListID = 72 Or row.QueueListID = 525 Or row.QueueListID = 74 Then
                                            quote += row.QueueListID + ","
                                        End If
                                    Next
                                    If quote.Length > 0 Then
                                        quote = quote.Substring(0, quote.Length - 1)
                                    End If
                                End Code
                                <input type="hidden" id="quoteQueue" value="[@quote]" />
                            </div>
                            <div class="col-md-3">
                                <label>
                                    @Html.CheckBoxFor(Function(model) model.CallWatch)
                                    <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Active Call Watch</span>
                                </label>
                                @Html.DropDownListFor(Function(model) model.CallWatchLevel, New SelectList(Model.CallWatchTypeList, "Value", "Text", Model.CallWatchLevel), New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Html.HiddenFor(Function(model) model.CallWatchID)
                            </div>
                        </div>
                        <div class="row">
                            @If Model.RandDList(0).MenuID Is Nothing Then
                                Model.RandDList(0).MenuID = 0
                            End If
                            <div class="col-md-12">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.Label("Menu Item of Concern", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                        &nbsp;&nbsp;<span style="color:red !important;"><span id="menuPathError"></span></span>
                                    </li>
                                </ul>
                                @*@Html.DropDownListFor(Function(model) model.RandDList(0).MenuID, New SelectList(Model.GSSMenuItemsList, "MenuItemID", "MenuItemTitle", Model.RandDList(0).MenuID), "Select Menu Item", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "GSSMenuItemsList"})*@

                                <div class="containter">
                                    <div class="editor">
                                        @Html.DevExpress().ComboBox(Sub(settings)
                                                                        settings.Name = "GSSMenuItemsList"
                                                                        settings.Width = Unit.Percentage(100)
                                                                        settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                        settings.Properties.DropDownStyle = DropDownStyle.DropDown
                                                                        settings.Properties.ClientSideEvents.SelectedIndexChanged = "function(s,e){SelectedMenu(s,e);}"
                                                                        settings.Properties.NullText = "Select Menu Item"
                                                                        settings.Properties.TextField = "MenuItemTitle"
                                                                        settings.Properties.NullTextDisplayMode = NullTextDisplayMode.UnfocusedAndFocused
                                                                        settings.Properties.ValueField = "MenuItemID"
                                                                        settings.PreRender = Sub(sender, e)
                                                                                                 Dim list As MVCxComboBox = sender
                                                                                                 list.SelectedItem = list.Items.FindByValue(Model.RandDList(0).MenuID.ToString())
                                                                                             End Sub
                                                                    End Sub).BindList(Model.GSSMenuItemsList).GetHtml

                                    </div>
                                </div>
                                @Html.HiddenFor(Function(model) model.RandDList(0).MenuID)
                            </div>
                        </div>

                        @Code
                            Dim Numbers() As Integer = {0, -1}
                        End Code
                        @If Numbers.Contains(Model.RandDList(0).SelID) = False And Numbers.Contains(Model.RandDList(0).SelID_Seq) = False Then
                            'Old Menu Items
                            @<div class="row">
                                <div class="col-md-3">
                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("SelectionID/Seq", New With {.class = "TitleGrayOblique"})
                                        </li>
                                        <li>
                                            <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="selSeqError"></span></span>
                                        </li>
                                    </ul>
                                    @Html.TextBoxFor(Function(model) model.RandDList(0).SelID, New With {.class = "ControlsFormat", .style = "width:45%;", .id = "SelectionID"})
                                    @Html.TextBoxFor(Function(model) model.RandDList(0).SelID_Seq, New With {.class = "ControlsFormat", .style = "width:45%;", .id = "Sequence"})
                                </div>
                                <div class="col-md-9">
                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("Menu Path of Concern", New With {.class = "TitleGrayOblique"})
                                        </li>
                                        <li>
                                            <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="menuPathError"></span></span>
                                        </li>
                                    </ul>
                                    <div style="width:100%;">
                                        <div class="col-sm-4 clearpadding">
                                            @Html.DropDownListFor(Function(model) model.RandDList(0).MASModuleSelected, New SelectList(Model.MASModuleList, "MODULEID", "MODULETITLE", Model.RandDList(0).SelID), "Select Module", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "MASModuleList"})
                                        </div>
                                        <div class="col-sm-2 clearpadding">
                                            @Html.DropDownListFor(Function(model) model.RandDList(0).MASHeaderSelected, New SelectList(Model.MASHeaderList, "HEADERID", "HEADERTITLE", Model.RandDList(0).SelID_Seq), "Select Header", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "MASHeaderList"})
                                        </div>
                                        <div class="col-sm-6 clearpadding">
                                            @Html.TextBoxFor(Function(model) model.RandDList(0).Menu_Path, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .Placeholder = "Enter Menu Title", .id = "TitleMenuItem"})
                                        </div>
                                    </div>
                                </div>
                            </div>
                        End If

                        <div class="row">
                            <div class="col-md-3">

                                <ul class="tooltip-end">
                                    <li>
                                        @Html.Label("Incident Number", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>

                                        @code
                                            If Model.RandDList(0).IncidentID Is Nothing AndAlso Model.RandDList(0).ExhibitsIncident Is Nothing Then

                                                @<a href="javascript:ShowIncident()">Add New Incident</a>
                                            End If
                                        End Code

                                    </li>
                                </ul>
                                @Code


                                    If Not (Model.RandDList(0).IncidentID) Is Nothing Then
                                        'If an incident exists then shows the incident number
                                        @Html.DisplayFor(Function(model) model.RandDList(0).IncidentID, New With {.class = "ControlsFormat", .style = "width:45%", .id = "IncidentId"})

                                    ElseIf (Model.RandDList(0).IncidentID) Is Nothing AndAlso Not (Model.RandDList(0).ExhibitsIncident) Is Nothing Then
                                        'If an Exhibits Incident exists but Incident number then shows the Exhibits Incident
                                        @Html.DisplayFor(Function(model) model.RandDList(0).ExhibitsIncident, New With {.class = "ControlsFormat", .style = "width:45%"})
                                    End If



                                    If Not (Model.RandDList(0).IncidentID) Is Nothing Or Not (Model.RandDList(0).ExhibitsIncident) Is Nothing Then
                                        @<input type="hidden" id="previoIncidentID" value="@Model.RandDList(0).IncidentID" />

                                        'Shows Incident Call Count
                                        @If Model.RandDList(0).CallIncidentCount >= 1 Then
                                            @code
                                                Dim IncidentCount = "(" + Model.RandDList(0).CallIncidentCount.ToString + ")"

                                            end code
                                            'Shows link with list of calls that has attached the same incident number
                                            @<a href="javascript:void(0);" onclick="IncidentCallsModal.Show();" title="Incident Call Count">@IncidentCount</a>
                                                End If


                                    End if



                                End Code
                                &nbsp;



                                @Code
                                    Dim showRemoveIncidentLink = "block"

                                    Dim showRemoveIssueText = ""

                                    Dim urlStrIncidentID = ""


                                    If (Not String.IsNullOrEmpty(Model.RandDList(0).IncidentID) Or Not String.IsNullOrEmpty(Model.RandDList(0).ExhibitsIncident)) And Session("iDeptID") = 1 And Session("bManager") Then 'user is in R&D and is  manager

                                        showRemoveIssueText = "Remove Incident"
                                        showRemoveIncidentLink = "block"


                                        If Not (String.IsNullOrEmpty(Model.RandDList(0).IncidentID)) Then
                                            'If an incident exists then remove the incident number
                                            urlStrIncidentID = "javascript: IncidentCleanup('" + Model.SIID.ToString + "', 'Incident')"
                                        Else
                                            'If an Exhibits Incident exists but Incident number then remove Exhibits Incident
                                            urlStrIncidentID = "javascript: IncidentCleanup('" + Model.SIID.ToString + "', 'ExhibitsIncident')"
                                        End If

                                    Else
                                        showRemoveIncidentLink = "hidden"
                                    End If


                                End Code
                                &nbsp;&nbsp;
                                <a id="linkIncidentMaint" href="@urlStrIncidentID" style="visibility:@showRemoveIncidentLink;">@showRemoveIssueText</a>






                            </div>


                            <div class="col-md-2">

                                @Html.Label("Incident Status", New With {.class = "TitleGrayOblique"})
                                @Html.DisplayFor(Function(model) model.RandDList(0).IncidentStatus, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                            </div>
                            <div class="col-md-2">
                                @Html.HiddenFor(Function(model) model.RandDList(0).IncidentstatusOriginal)
                                @Html.HiddenFor(Function(model) model.RandDList(0).CallIncidentCount)
                                @Html.HiddenFor(Function(model) model.IncidentInfo.StatusToRDFirstTime)

                            </div>


                        </div>






                        <div class="row">
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.RandDList(0).ExhibitsIssue, "Issue Number", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        @Code
                                            Dim showExhibitsIssueLink = "block"
                                            'Dim showExhibitsIssueLink = "hidden"
                                            Dim showExhibitsIssueText = "Edit"
                                            'Dim urlStrExhibitsIssue = "/Calls/RedOldSW?idurl=1&iID=" + Model.RandDList(0).AddressesIssue
                                            'Dim urlStrExhibitsIssue = Url.Action("EditSWIssue", "Calls", New With {.issueID = Model.IssueNumber})
                                            'Dim urlStrExhibitsIssue = "javascript: OpenIssue('" + Model.RandDList(0).ExhibitsIssue + "')"
                                            Dim urlStrExhibitsIssue = "/Calls/EditSWIssue/?issueID=" + Model.RandDList(0).ExhibitsIssue
                                            Dim issueCount = "(" + Model.RandDList(0).CallIssueCount.ToString + ")"
                                            If (Model.RandDList(0).ExhibitsIssue = "" Or Model.RandDList(0).ExhibitsIssue Is Nothing) And Session("iDeptID") <> 1 Then
                                                showExhibitsIssueLink = "hidden"
                                            ElseIf (Model.RandDList(0).ExhibitsIssue = "" Or Model.RandDList(0).ExhibitsIssue Is Nothing) And Session("iDeptID") = 1 Then
                                                showExhibitsIssueText = "Add New"
                                                showExhibitsIssueLink = "block"
                                                'urlStrExhibitsIssue = "/Calls/RedOldSW?idurl=4&iSIID=" + Model.SIID.ToString()
                                                'urlStrExhibitsIssue = Url.Action("AddSWIssue", "Calls", New With {.siid = Model.SIID, .Title = Model.Title, .description = "", .menuItemID = Model.RandDList(0).MenuID})
                                                urlStrExhibitsIssue = "javascript: AddIssue('" + Model.SIID.ToString + "','" + Model.Title.Replace("'", "\'") + "','" + Model.Title.Replace("'", "\'") + "','" + Model.RandDList(0).MenuID.ToString + "','" + Model.VerID.ToString + "')"
                                                'ElseIf Model.RandDList(0).ExhibitsIssueStatus = "Dead Issue" And Session("iDeptID") = 1 Then
                                            ElseIf Model.RandDList(0).ExhibitsIssueStatusID = 8 And Session("iDeptID") = 1 Then
                                                If Model.RandDList(0).AddressesIssue <> "" Then
                                                    showExhibitsIssueText = "Remove Issue"
                                                    showExhibitsIssueLink = "block"
                                                    urlStrExhibitsIssue = "javascript: RemoveIssue('" + Model.SIID.ToString + "','" + Model.RandDList(0).ExhibitsIssue.ToString + "','" + Model.RandDList(0).IsInIssueMaint.ToString + "')"
                                                Else
                                                    showExhibitsIssueText = "Add New"
                                                    showExhibitsIssueLink = "block"
                                                    'urlStrExhibitsIssue = "/Calls/RedOldSW?idurl=4&iSIID=" + Model.SIID.ToString()
                                                    'urlStrExhibitsIssue = Url.Action("AddSWIssue", "Calls", New With {.siid = Model.SIID, .Title = Model.Title, .description = "", .menuItemID = Model.RandDList(0).MenuID})
                                                    urlStrExhibitsIssue = "javascript: AddIssue('" + Model.SIID.ToString + "','" + Model.Title.Replace("'", "\'") + "','" + Model.Title.Replace("'", "\'") + "','" + Model.RandDList(0).MenuID.ToString + "','" + Model.VerID.ToString + "')"
                                                End If
                                            ElseIf Model.RandDList(0).ExhibitsIssue <> "" And Session("iDeptID") = 1 Then
                                                If Model.RandDList(0).AddressesIssue = "" Then
                                                    showExhibitsIssueText = "Remove Issue"
                                                    showExhibitsIssueLink = "block"
                                                    urlStrExhibitsIssue = "javascript: RemoveIssue('" + Model.SIID.ToString + "','" + Model.RandDList(0).ExhibitsIssue.ToString + "','" + Model.RandDList(0).IsInIssueMaint.ToString + "')"
                                                End If
                                            ElseIf (Session("bAdmin") = True Or Session("EmpID") = 137) And Model.RandDList(0).IsInIssueMaint = False Then 'Only Admins and Luke Frey can see this link
                                                showExhibitsIssueText = "Issue Cleanup"
                                                showExhibitsIssueLink = "block"
                                                urlStrExhibitsIssue = "javascript: IssueCleanup('" + Model.SIID.ToString + "')"
                                            ElseIf Model.RandDList(0).IsInIssueMaint = False Then 'Will not show the Edit because not in the New Issue Maintenance
                                                showExhibitsIssueLink = "hidden"
                                            End If
                                        End Code
                                        &nbsp;&nbsp;<a id="linkIssueMaint" href="@urlStrExhibitsIssue" style="visibility:@showExhibitsIssueLink;">@showExhibitsIssueText</a>
                                    </li>
                                </ul>
                                @Html.DisplayFor(Function(model) model.RandDList(0).ExhibitsIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Html.HiddenFor(Function(model) model.RandDList(0).CallIssueCount)
                                @Html.HiddenFor(Function(model) model.RandDList(0).DeadIssue)
                                @If Model.RandDList(0).CallIssueCount > 1 Then
                                    @*@<span>&nbsp;&nbsp;# Of Calls:</span>*@
                                    @<a href="javascript:void(0);" onclick="issueCallsModal.Show();" title="Issue Call Count">@issueCount</a>
                                End If
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).ExhibitsIssueStatus, "Issue Status", New With {.class = "TitleGrayOblique"})
                                @Html.DisplayFor(Function(model) model.RandDList(0).ExhibitsIssueStatus, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Html.HiddenFor(Function(model) model.RandDList(0).ExhibitsIssueStatus)
                                @Html.HiddenFor(Function(model) model.RandDList(0).ExhibitsIssueStatusID)
                            </div>
                            <div class="col-md-3">
                                @Code
                                    Dim bAIssue As Boolean = False
                                    Dim bEIssue As Boolean = False
                                    Dim bRes As Boolean = False
                                    Dim bBill As Boolean = False
                                    Dim bProj As Boolean = False
                                    Dim bProjClosed As Boolean = True

                                    If Not Model.RandDList Is Nothing Then
                                        bProj = Model.RandDList(0).Project
                                        If (Model.RandDList(0).ProjectChildren <> 0 Or Model.RandDList(0).ProjectChildrenClosed <> 0) And bProj = True Then
                                            If Model.RandDList(0).ProjectChildren = Model.RandDList(0).ProjectChildrenClosed Then
                                                bProjClosed = False
                                            End If
                                        End If
                                    End If

                                    If Not Model.BillingList Is Nothing Then
                                        If Model.BillingList(0).TotalAmtBilled IsNot Nothing Then
                                            If Model.BillingList(0).TotalAmtBilled <> "0" And Model.BillingList(0).TotalAmtBilled <> "" Then
                                                bBill = True
                                            End If
                                        End If
                                    End If

                                    If Model.RandDList(0).ExhibitsIssue IsNot Nothing Then
                                        'Resolved: 5, Released: 6, Update: 7, Dead Issue: 8
                                        If Model.RandDList(0).ExhibitsIssueStatusID = 5 Or Model.RandDList(0).ExhibitsIssueStatusID = 6 Or Model.RandDList(0).ExhibitsIssueStatusID = 7 Or Model.RandDList(0).ExhibitsIssueStatusID = 8 Then
                                            bRes = True
                                        Else
                                            bRes = False
                                        End If
                                        bEIssue = True
                                    Else
                                        If Session("iDeptID") <> 1 Then
                                            bRes = False
                                            bEIssue = False
                                        End If
                                    End If

                                    'If Model.RandDList(0).ExhibitsIssue IsNot Nothing Then
                                    '    If Model.RandDList(0).ExhibitsIssueStatus = "Resolved" Or Model.RandDList(0).ExhibitsIssueStatus = "Released" Or Model.RandDList(0).ExhibitsIssueStatus = "Dead Issue" Or Model.RandDList(0).ExhibitsIssueStatus = "Update" Then
                                    '        bRes = True
                                    '    Else
                                    '        bRes = False
                                    '    End If
                                    '    bEIssue = True
                                    'Else
                                    '    If Session("iDeptID") <> 1 Then
                                    '        bRes = False
                                    '        bEIssue = False
                                    '    End If
                                    'End If

                                    'If Model.RandDList(0).AddressesIssue IsNot Nothing Then
                                    '    bAIssue = True
                                    '    If bRes = False Then
                                    '        If Model.RandDList(0).AddressesIssueStatus = "Resolved" Or Model.RandDList(0).AddressesIssueStatus = "Released" Or Model.RandDList(0).AddressesIssueStatus = "Dead Issue" Or Model.RandDList(0).AddressesIssueStatus = "Update" Then
                                    '            bRes = True
                                    '        Else
                                    '            bRes = False
                                    '        End If
                                    '        'Else
                                    '        '    bRes = False
                                    '    End If
                                    'Else
                                    '    If Session("iDeptID") <> 1 Then
                                    '        bAIssue = False
                                    '    End If
                                    'End If

                                    'If Model.IssueNumber IsNot Nothing Then
                                    '    If Model.IssueStatus = "Resolved" Or Model.IssueStatus = "Released" Or Model.IssueStatus = "Dead Issue" Or Model.IssueStatus = "Update" Then
                                    '        bRes = True
                                    '    Else
                                    '        bRes = False
                                    '    End If
                                    '    bEIssue = True
                                    'Else
                                    '    If Session("iDeptID") <> 1 Then
                                    '        bRes = False
                                    '        bEIssue = False
                                    '    End If
                                    'End If


                                    Dim showClose = "block"
                                    If Session("iDeptID") <> 1 And bProj = True And bBill = True Then
                                        showClose = "hidden"
                                    ElseIf Session("iDeptID") = 1 And Session("bSuper") = True Then
                                        showClose = "block"
                                    ElseIf Session("iDeptID") = 1 And (bAIssue = True Or bEIssue = True) And bRes = False Then
                                        showClose = "hidden"
                                    ElseIf Session("iDeptID") <> 1 And (bProj = True And bBill = True And bProjClosed) Then
                                        showClose = "hidden"
                                    ElseIf bProjClosed = False Then
                                        showClose = "hidden"
                                    Else
                                        showClose = "block"
                                    End If
                                End Code
                                @If Model.CloseCall Then
                                    @<input name="OpenCall" type="checkbox" id="ReopenCall" onclick="javascript:ReopenPopup(this, @Model.SIID);" />
                                    @<span class="TitleGrayOblique checkbox-label">@Html.Label("Re-Open Call")</span>
                                    @Html.HiddenFor(Function(model) model.SplitCallOpen_RefNo)
                                    @Html.HiddenFor(Function(model) model.SplitCallOpen_Reopend)
                                Else
                                    @<span style="visibility:@showClose;">
                                        <input name="CloseCall" type="checkbox" id="CloseCall" />
                                        <span class="TitleGrayOblique checkbox-label">@Html.Label("Close Call")</span>
                                    </span>
                                End If
                            </div>
                            <div class="col-md-3">

                            </div>
                        </div>
                        <div class="row">
                            @Code
                                Dim showCallCloudDisplay = "block"
                                Dim showCallCloudButtonText = "glyphicon glyphicon-chevron-down"
                                If Model.IsCloudRequest = False Then
                                    showCallCloudDisplay = "none"
                                    showCallCloudButtonText = "glyphicon glyphicon-chevron-right"
                                End If

                                Dim showCallCloud = "none"
                                If Model.IsCloudRequest = True Then
                                    showCallCloud = "block"
                                End If

                                Dim showVPNDiv = "none"
                                If Model.ProblemID = "153" Then
                                    showVPNDiv = "block"
                                End If

                                Dim showTimeDiv = "none"
                                If Model.ProblemID = "162" Or Model.ProblemID = "164" Or Model.ProblemID = "169" Or Model.ProblemID = "170" Or Model.ProblemID = "143" Or Model.ProblemID = "144" Then
                                    showTimeDiv = "block"
                                End If

                                Dim showTimeDivPastTime = "none"
                                Dim showTimeDivNoPastTime = "none"
                                If Model.CloudList IsNot Nothing Then
                                    If Model.CloudList(0).RequestDate IsNot Nothing And showTimeDiv = "block" Then
                                        If Model.CloudList(0).RequestDate.Value.Date = Now.Date Then
                                            showTimeDivNoPastTime = "block"
                                        Else
                                            showTimeDivPastTime = "block"
                                        End If
                                    End If
                                ElseIf showTimeDiv = "block" Then
                                    showTimeDivPastTime = "block"
                                End If

                                Dim showServersDiv = "none"
                                If Model.ProblemID = "144" Or Model.ProblemID = "164" Then
                                    showServersDiv = "block"
                                End If
                            End Code
                            <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer; display:@showCallCloud;" id="headingCallCloud" onclick="javascript:ShowPanel(btnCallCloud,callCloud)">
                                <label>
                                    <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                        <span id="btnCallCloud" class="@showCallCloudButtonText" style="color:#428bca;"></span>
                                        &nbsp;Cloud Request Information
                                    </span>
                                </label>
                            </div>
                            <div class="panel-body" id="callCloud" style="display:@showCallCloudDisplay;">
                                <div class="row">
                                    <div class="col-md-4">
                                        <ul class="tooltip-end">
                                            <li>
                                                @Html.Label("Request Date", New With {.class = "TitleGrayOblique"})
                                            </li>
                                            <li>
                                                <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                &nbsp;&nbsp;<label id="ValidateRequestDate" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                            </li>
                                        </ul>
                                        <div class='input-group date' id='dateRequestDiv'>
                                            <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="RequestDateTxt" value="@Model.CloudList(0).RequestDate_String" />
                                            @Html.HiddenFor(Function(model) model.CloudList(0).RequestDate)
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div id="DivVPN" style="display:@showVPNDiv">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <ul class="tooltip-end">
                                                <li>
                                                    <label class="TitleGrayOblique">Firewall Device Model</label>
                                                </li>
                                                <li>
                                                    <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                    &nbsp;&nbsp;<label id="ValidateFireWall" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                                </li>
                                            </ul>
                                            @Html.TextBoxFor(Function(model) model.CloudList(0).FireWall_Info, New With {.class = "dropdownFormat ControlwidthExtraPlus"})
                                        </div>
                                        <div class="col-md-4">
                                            <ul class="tooltip-end">
                                                <li>
                                                    <label class="TitleGrayOblique">WAN Address of End Point</label>
                                                </li>
                                                <li>
                                                    <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                    &nbsp;&nbsp;<label id="ValidateWan" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                                </li>
                                            </ul>
                                            @Html.TextBoxFor(Function(model) model.CloudList(0).Wan_Info, New With {.class = "dropdownFormat ControlwidthExtraPlus"})
                                        </div>
                                        <div class="col-md-4">
                                            <ul class="tooltip-end">
                                                <li>
                                                    <label class="TitleGrayOblique">Private Subnets for VPN</label>
                                                </li>
                                                <li>
                                                    <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                    &nbsp;&nbsp;<label id="ValidateVPN" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                                </li>
                                            </ul>
                                            @Html.TextBoxFor(Function(model) model.CloudList(0).VPN_Info, New With {.class = "dropdownFormat ControlwidthExtraPlus"})
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" id="DivTime" style="display:@showTimeDiv">
                                        <ul class="tooltip-end">
                                            <li>
                                                @Html.Label("Time", New With {.class = "TitleGrayOblique"})
                                            </li>
                                            <li>
                                                <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                &nbsp;&nbsp;<label id="ValidateRequestTime" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                            </li>
                                        </ul>
                                        <div id="DivTimeNoPastTime" style="display:@showTimeDivNoPastTime">
                                            <div class="form-group">
                                                <div class='input-group date' id='datetimeRequest'>
                                                    <input type='text' class="form-control Controlwidthtime ControlsFormat" id="RequestTimetextBox" name="RequestTimetextBox" value="@Model.CloudList(0).RequestTime_String" />
                                                    @Html.HiddenFor(Function(model) model.CloudList(0).RequestTime)
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon-time glyphicon  "></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="DivTimePastTime" style="display:@showTimeDivPastTime">
                                            <div class="form-group">
                                                <div class='input-group date' id='datetimeRequest2'>
                                                    <input type='text' class="form-control Controlwidthtime ControlsFormat" id="RequestTimeAllHourstextBox" name="RequestTimeAllHourstextBox" value="@Model.CloudList(0).RequestTime_String" />
                                                    @Html.HiddenFor(Function(model) model.CloudList(0).RequestTimeAllHours)
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon-time glyphicon  "></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="color:red; display:@showServersDiv" id="DivServers">
                                        <ul class="tooltip-end">
                                            <li>
                                                @Html.Label("Servers", New With {.class = "TitleGrayOblique"})
                                            </li>
                                            <li>
                                                <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                &nbsp;&nbsp;<label id="ValidateServers" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                            </li>
                                        </ul>

                                        @Code
                                            Dim servers As String = ""
                                            Dim serversID As String = ""
                                            If Not Model.CloudList(0).Servers Is Nothing Then
                                                For i As Integer = 0 To Model.CloudList(0).Servers.Count - 1
                                                    servers += Model.CloudList(0).Servers(i).CSTDesc + ", "
                                                    serversID += Model.CloudList(0).Servers(i).CSTID.ToString() + ","
                                                Next
                                                If servers.Length > 0 Then
                                                    servers = servers.Substring(0, servers.Length - 2)
                                                End If
                                                If serversID.Length > 0 Then
                                                    serversID = serversID.Substring(0, serversID.Length - 1)
                                                End If
                                            End If
                                        End Code
                                        @Html.HiddenFor(Function(model) model.CloudList(0).ServersSelected, New With {.id = "Serversid"})
                                        <div id="DivServersUpdate">
                                            @*@Html.Action("MultiSelectPartial", "Cloud", New With {.selectedValues = serversID})*@
                                            @*@Html.Action("MultiSelectPartial", "Cloud")*@
                                            @Html.Action("MultiSelectPartial", "Calls", New With {.type = "Cloud", .selectedValues = serversID})
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="DivServerType" style="display:@showTimeDiv">
                                    <div class="col-md-4">
                                        <ul class="tooltip-end">
                                            <li>
                                                @Html.Label("Server Type", New With {.class = "TitleGrayOblique"})
                                            </li>
                                            <li>
                                                <span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span>
                                                &nbsp;&nbsp;<label id="ValidateRequestDate" class="TitleGrayOblique" style="color:red;display:none;">This field is required.</label>
                                            </li>
                                        </ul>
                                        <div class='input-group date' id='ServerTypeDiv'>

                                            @Html.DropDownListFor(Function(Model) Model.CloudList(0).ServerType, New SelectList(ViewData("RequestCloudServers"), "Value", "Text", Model.CloudList(0).ServerType), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "requestServerDropDownList", .required = True})

                                            @Html.HiddenFor(Function(model) model.CloudList(0).ServerType)

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>





                        <div class="row">
                            @Code
                                Dim showCallOptionsDisplay = "block"
                                Dim showCallOptionsButtonText = "glyphicon glyphicon-chevron-down"
                                If Session("ShowCallOptions") = "False" Then
                                    showCallOptionsDisplay = "none"
                                    showCallOptionsButtonText = "glyphicon glyphicon-chevron-right"
                                End If
                            End Code
                            <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingCallOptions" onclick="javascript:ShowPanel(btnCallOptions,callOptions)">
                                <label>
                                    <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                        <span id="btnCallOptions" class="@showCallOptionsButtonText" style="color:#428bca;"></span>
                                        &nbsp;Call Options
                                    </span>
                                </label>
                            </div>
                            <div class="panel-body" id="callOptions" style="display:@showCallOptionsDisplay;">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>
                                            @Html.CheckBoxFor(Function(model) model.CallOn)
                                            <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Call On</span>
                                        </label>
                                        <div class="form-group">
                                            <div class='input-group date' id='datetimepicker3'>
                                                <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="callHoldDateText" value="@Model.CallOnDate" />
                                                @Html.HiddenFor(Function(model) model.CallOnDate)
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label>
                                            @Html.CheckBoxFor(Function(model) model.CallHold)
                                            <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Call Hold/Status</span>
                                        </label>
                                        @Html.TextBoxFor(Function(model) model.CallHoldStatus, New With {.class = "ControlsFormat ControlwidthExtraPlus"})
                                    </div>
                                    <div class="col-md-3">
                                        <a href="javascript: callWatchModal.Show();">
                                            Who's watching the call
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a href='@Url.Action("ProjectView", "Quote", New With {.id = Model.UID})' target="_blank">
                                            Completed Projects
                                        </a>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        @Html.LabelFor(Function(model) model.PercentComplete, "Percent Complete", New With {.class = "TitleGrayOblique"})
                                        @Html.TextBoxFor(Function(model) model.PercentComplete, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                    </div>
                                    <div class="col-md-3">
                                        <span class="TitleGrayOblique">
                                            @Html.Label("Entry Method")
                                        </span>
                                        <span class="TitleBlack ControlwidthEdit ControlsFormat backgroundgray">
                                            @Html.DisplayFor(Function(model) model.EntryMethod)
                                        </span>
                                    </div>
                                    <div class="col-md-6">

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showRandDDisplay = "block"
                        Dim showRanDButtonText = "glyphicon glyphicon-chevron-down"
                        If Session("ShowRandD") = "False" Then
                            showRandDDisplay = "none"
                            showRanDButtonText = "glyphicon glyphicon-chevron-right"
                        End If
                    End Code
                    <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingRandDInfo" onclick="javascript:ShowPanel(btnRandDInfo,randdInfo)">
                        <label>
                            <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                <span id="btnRandDInfo" class="@showRanDButtonText" style="color:#428bca;"></span>
                                &nbsp;Programming Information
                            </span>
                        </label>
                    </div>
                    <div class="panel-body" id="randdInfo" style="display:@showRandDDisplay;">
                        <div class="row">
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).Orig_EstHours, "Orig. Estimated Hours", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).Orig_EstHours, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).EstHours, "Estimated Hours", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).EstHours, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).EstCompletion, "Estimated Completion", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker4'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="estCompletedDateText" value="@Model.RandDList(0).EstCompletion" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).EstCompletion)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).EstDelivery, "Estimated Delivery", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker5'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="estDeliveryDateText" value="@Model.RandDList(0).EstDelivery" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).EstDelivery)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            @*<div class="col-md-3">
                                    <label>
                                        @Html.CheckBoxFor(Function(model) model.RandDList(0).AddressIssue, New With {.disabled = "disabled"})
                                        <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Addresses Issue</span>
                                    </label>
                                </div>*@
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>
                                    @Html.CheckBoxFor(Function(model) model.RandDList(0).Project)
                                    <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Project</span>
                                </label>
                                @*@Html.DropDownListFor(Function(model) model.RandDList(0).ProjectName, New SelectList(Model.RandDList(0).ProjectList, "ISID", "IS_Desc", Model.RandDList(0).ProjectName), New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "ddlProjectName"})*@
                                <div class="input-group" style="width:100%;">
                                    <div class="input-group">
                                        @Html.TextBoxFor(Function(model) model.RandDList(0).ProjectName, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "projectName"})
                                        @Html.HiddenFor(Function(model) model.RandDList(0).ProjectID, New With {.id = "projectID"})
                                        <div class="input-group-addon" style="padding: 0 !important; border: 0px !important;">
                                            <button type="button" class="btn btn-default dropdownFormat" aria-label="Bold" style="background-color: #eee;border: 1px solid #ccc; width:38px; height:30px;" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <span class="fa fa-caret-down">
                                                </span>
                                            </button>
                                            @If Model.RandDList(0).ProjectList.Count > 0 Then
                                                @<ul class="dropdown-menu dropdown" style="width:100%;">
                                                    @For i As Integer = 0 To Model.RandDList(0).ProjectList.Count - 1
                                                        @<li>
                                                            <a href="javascript:SetProjectName(@Model.RandDList(0).ProjectList(i).SI_ProjID,'@Model.RandDList(0).ProjectList(i).SI_Proj_Desc')">@Model.RandDList(0).ProjectList(i).SI_Proj_Desc</a>
                                                        </li>
                                                    Next
                                                </ul>
                                            Else
                                                @<ul class="dropdown-menu dropdown-menu-right" style="width:100%;">
                                                    <li>
                                                        No Projects
                                                    </li>
                                                </ul>
                                            End If
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).Maint_StartDt, "Maintenance Start Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker6'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="startDateText" value="@Model.RandDList(0).Maint_StartDt" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).Maint_StartDt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).ProjectStartDt, "Start Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker6'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="startDateText" value="@Model.RandDList(0).ProjectStartDt" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).ProjectStartDt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).ProjectCompDt, "Projected Completion", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker7'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="projCompDateText" value="@Model.RandDList(0).ProjectCompDt" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).ProjectCompDt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.AllActionsList(countIndex).Internal_Status, "Internal Status", New With {.class = "TitleGrayOblique"})
                                @Html.DropDownListFor(Function(model) model.InternalStatus, New SelectList(Model.AllActionsList(countIndex).InternalStatusList, "ISID", "IS_Desc", Model.AllActionsList(countIndex).Internal_Status), "Select Status", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).InternalDueDt, "Internal Due Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker8'>
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="internalDueDtText" value="@Model.RandDList(0).InternalDueDt" />
                                    @Html.HiddenFor(Function(model) model.RandDList(0).InternalDueDt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.RandDList(0).Coders, "Coders", New With {.class = "TitleGrayOblique"})
                                    </li>
                                </ul>
                                @Code
                                    Dim coders As String = ""
                                    Dim codersID As String = ""
                                    If Not Model.RandDList(0).Coders Is Nothing Then
                                        For i As Integer = 0 To Model.RandDList(0).Coders.Count - 1
                                            coders += Model.RandDList(0).Coders(i).Emp_Name + ", "
                                            codersID += Model.RandDList(0).Coders(i).RD_EmpID.ToString() + ","
                                        Next
                                        If coders.Length > 0 Then
                                            coders = coders.Substring(0, coders.Length - 2)
                                        End If
                                        If codersID.Length > 0 Then
                                            codersID = codersID.Substring(0, codersID.Length - 1)
                                        End If
                                    End If
                                End Code
                                @Html.HiddenFor(Function(model) model.RandDList(0).Coders, New With {.id = "codersModel", .Value = codersID})
                                @Html.Action("MultiSelectPartial", "Calls", New With {.type = "Coders", .selectedValues = codersID})
                            </div>
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.RandDList(0).Testers, "Testers", New With {.class = "TitleGrayOblique"})
                                    </li>
                                </ul>
                                @Code
                                    Dim testers As String = ""
                                    Dim testersID As String = ""
                                    If Not Model.RandDList(0).Testers Is Nothing Then
                                        For i As Integer = 0 To Model.RandDList(0).Testers.Count - 1
                                            testers += Model.RandDList(0).Testers(i).Emp_Name + ", "
                                            testersID += Model.RandDList(0).Testers(i).RD_EmpID.ToString() + ","
                                        Next
                                        If testers.Length > 0 Then
                                            testers = testers.Substring(0, testers.Length - 2)
                                        End If
                                        If testersID.Length > 0 Then
                                            testersID = testersID.Substring(0, testersID.Length - 1)
                                        End If
                                    End If
                                End Code
                                @Html.HiddenFor(Function(model) model.RandDList(0).Testers, New With {.id = "testersModel", .Value = testersID})
                                @Html.Action("MultiSelectPartial", "Calls", New With {.type = "Testers", .selectedValues = testersID})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.Label("Quote/Rev", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        &nbsp;
                                        @If Not Model.RandDList(0).QuID Is Nothing And Not Model.RandDList(0).Quote Is Nothing And Not Model.RandDList(0).Revision Is Nothing Then
                                            @Html.ActionLink("Edit Quote", "QuoteEditInternal", "Quote", New With {.id = Model.RandDList(0).QuID}, New With {.target = "_blank"})
                                        Else
                                            @Html.ActionLink("Generate Quote", "RequestQuoteInternal", "Quote", New With {.id = Model.SIID}, New With {.target = "_self"})
                                        End If
                                    </li>
                                </ul>
                                @Code
                                    If Model.RandDList(0).Quote IsNot Nothing Then
                                        @Html.DisplayFor(Function(model) model.RandDList(0).Quote, New With {.class = "ControlsFormat", .style = "width:45%;"})
                                    End If
                                    If Model.RandDList(0).Revision IsNot Nothing Then
                                        @<span> - </span>
                                        @Html.DisplayFor(Function(model) model.RandDList(0).Revision, New With {.class = "ControlsFormat", .style = "width:45%;"})
                                    End If
                                End Code
                                @Html.HiddenFor(Function(model) model.RandDList(0).Quote)
                                @Html.HiddenFor(Function(model) model.RandDList(0).QuID)
                                @Html.HiddenFor(Function(model) model.RandDList(0).Revision)
                            </div>
                            <div class="col-md-1">
                                @Html.LabelFor(Function(model) model.RandDList(0).Rank, "Rank", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).Rank, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.RandDList(0).AxosoftID, "Team ID", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).AxosoftID, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.RandDList(0).ClinicCode, "Clinic Code", New With {.class = "TitleGrayOblique"})
                                @Html.DisplayFor(Function(model) model.RandDList(0).ClinicCode, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                <input type="hidden" id="clinicCode" value="@Model.RandDList(0).ClinicCode" />
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.RandDList(0).GPID, "ARC", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).GPID, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.RandDList(0).ForumnID, "Forum ID", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).ForumnID, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.RandDList(0).ExhibitsIssue, "Exhibits Issue", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        &nbsp;&nbsp;<span style="color:red !important;"><span id="issuesError"></span></span>
                                    </li>
                                </ul>
                                @If Model.RandDList(0).ExhibitsIssue <> "" Then
                                    @If Model.RandDList(0).ExhibitsIssueStatus = "Dead Issue" AndAlso Model.RandDList(0).AddressesIssue = "" Then
                                        @Html.TextBoxFor(Function(model) model.RandDList(0).ExhibitsIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                    Else
                                        @Html.DisplayFor(Function(model) model.RandDList(0).ExhibitsIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        @Html.HiddenFor(Function(model) model.RandDList(0).ExhibitsIssue)
                                    End If
                                Else
                                    @Html.TextBoxFor(Function(model) model.RandDList(0).ExhibitsIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                End If
                                @Html.HiddenFor(Function(model) model.RandDList(0).ExhibitsIssueOrig)
                                @Html.HiddenFor(Function(model) model.RandDList(0).CallIssueCount)
                                @Html.HiddenFor(Function(model) model.RandDList(0).DeadIssue)
                            </div>
                            <div class="col-md-2">
                                @Html.LabelFor(Function(model) model.RandDList(0).AddressesIssue, "Addresses Issue", New With {.class = "TitleGrayOblique"})
                                @*@Html.TextBoxFor(Function(model) model.RandDList(0).AddressesIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})*@
                                @Html.DisplayFor(Function(model) model.RandDList(0).AddressesIssue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Html.HiddenFor(Function(model) model.RandDList(0).AddressesIssue)
                                @Html.HiddenFor(Function(model) model.RandDList(0).AddressesIssueOrig)
                            </div>


                            <div class="col-md-2">

                                @Html.LabelFor(Function(model) model.RandDList(0).ExhibitsIncident, "Exhibits Incident", New With {.class = "TitleGrayOblique"})

                                @If Model.RandDList(0).IncidentID Is Nothing Then
                                    @Html.TextBoxFor(Function(model) model.RandDList(0).ExhibitsIncident, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                End If

                                @Code
                                    Dim showRemoveExhibitsIncidentLink = "block"

                                    Dim showRemoveExhibitsIncidentText = ""

                                    Dim urlStrExhibitsIncidentID = ""

                                    If Model.RandDList(0).ExhibitsIncident <> "" And Session("iDeptID") = 1 And Session("bManager") Then 'user is in R&D and is  manager

                                        showRemoveExhibitsIncidentText = "Remove Incident"
                                        showRemoveExhibitsIncidentLink = "block"
                                        urlStrExhibitsIncidentID = "javascript: IncidentCleanup('" + Model.SIID.ToString + "', 'ExhibitsIncident')"
                                    Else
                                        showRemoveExhibitsIncidentLink = "hidden"
                                    End If


                                End Code
                                &nbsp;&nbsp;<a id="linkExhibitsIncidentMaint" href="@urlStrExhibitsIncidentID" style="visibility:@showRemoveExhibitsIncidentLink;">@showRemoveExhibitsIncidentText</a>






                            </div>



                            <div class="col-md-1">
                            </div>




                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.RandDList(0).ProgramName, "Program Name", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).ProgramName, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-3">
                                @Html.Label("WO/Seq", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).WO, New With {.class = "ControlsFormat", .style = "width:45%;"})
                                @Html.TextBoxFor(Function(model) model.RandDList(0).WO_Seq, New With {.class = "ControlsFormat", .style = "width:45%;"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <span class="TitleGrayOblique">
                                    @Html.LabelFor(Function(model) model.RandDList(0).RandDNotes, "Notes")
                                </span>
                                @Html.TextAreaFor(Function(model) model.RandDList(0).RandDNotes, New With {.class = "ControlsFormat ControlwidthExtraPlus TxtMultilineHeigth ", .onKeyDown = "this.onEnterPress"})
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            @*Incident info*@
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showIncidentDisplay = "block"
                        Dim showIncidentButtonText = "glyphicon glyphicon-chevron-down"
                        If (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Then
                            showIncidentDisplay = "none"
                            showIncidentButtonText = "glyphicon glyphicon-chevron-right"
                        End If


                    End Code

                    <div class="row" id="IncidentSection" style="display:@showIncidentDisplay;">



                        <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingCallOptions" onclick="javascript:ShowPanel(btnIncidentOptions,IncidentsOptions)">
                            <label>
                                <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                    <span id="btnIncidentOptions" class="@showIncidentButtonText" style="color:#428bca;"></span>
                                    &nbsp;Incident Information
                                </span>
                            </label>
                        </div>


                        <div class="panel-body" id="IncidentsOptions">

                            <div class="row">
                                <div class="col-md-2">


                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("", "Status*", New With {.class = "TitleGrayOblique"})

                                        </li>
                                        <li>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.IncidentInfo.Status, String.Empty, New With {.style = "color:red;!important"})
                                        </li>
                                    </ul>
                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then

                                        @Html.DisplayFor(Function(model) model.IncidentInfo.StatusDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else

                                        @if ((Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing)) Then 'New incident or main call with incident

                                            @Html.DropDownListFor(Function(model) model.IncidentInfo.Status, New SelectList(ViewData("IncidentStatus"), "ID", "Desc", Model.IncidentInfo.Status), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "IncidentStatus"})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.StatusDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        End If

                                    End if
                                </div>


                                <div class="col-md-2">

                                    @Html.Label("", "Created By", New With {.class = "TitleGrayOblique"})

                                    @Html.DisplayFor(Function(model) model.IncidentInfo.SubmitName, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                </div>
                                <div class="col-md-2">
                                    @Html.Label("", "Created Date", New With {.class = "TitleGrayOblique"})
                                    @Html.DisplayFor(Function(model) model.IncidentInfo.Submit_Dt, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})


                                </div>
                            </div>




                            <div class="row">
                                <div class="col-md-12">

                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("", "Brief Description*", New With {.class = "TitleGrayOblique"})

                                        </li>
                                        <li>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.IncidentInfo.BriefDescription, String.Empty, New With {.style = "color:red;!important"})
                                        </li>
                                    </ul>
                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.BriefDescription, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else


                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident


                                            @Html.TextAreaFor(Function(model) model.IncidentInfo.BriefDescription, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True, .maxlength = 250, .minlength = 10})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.BriefDescription, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        End If
                                    end if
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">

                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("", "Exhibited Behavior*", New With {.class = "TitleGrayOblique"})

                                        </li>
                                        <li>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.IncidentInfo.ExhibitedBehavior, String.Empty, New With {.style = "color:red;!important"})
                                        </li>
                                    </ul>

                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.ExhibitedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident


                                            @Html.TextAreaFor(Function(model) model.IncidentInfo.ExhibitedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True, .minlength = 10})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.ExhibitedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        End If
                                    end if
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <ul class="tooltip-end">
                                        <li>
                                            @Html.Label("", "Expected Behavior*", New With {.class = "TitleGrayOblique"})
                                        </li>
                                        <li>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.IncidentInfo.ExpectedBehavior, String.Empty, New With {.style = "color:red;!important"})
                                        </li>
                                    </ul>

                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.ExpectedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident

                                            @Html.TextAreaFor(Function(model) model.IncidentInfo.ExpectedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True, .minlength = 10})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.ExpectedBehavior, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        End If
                                    end if
                                </div>


                            </div>


                            <div Class="row">
                                <div Class="col-md-2">
                                    <Label Class="TitleGrayOblique">Changed When</Label>

                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.ChangedWhenDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else

                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident


                                            @Html.DropDownListFor(Function(model) model.IncidentInfo.Changed_When, New SelectList(ViewData("IncidentChangeWhen"), "ID", "Desc", Model.IncidentInfo.Incident_Replication), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.ChangedWhenDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        End If

                                    end if
                                </div>
                                <div Class="col-md-2">
                                    @Html.Label("", "Suspect Issue", New With {.class = "TitleGrayOblique"})
                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.Suspect_Issue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Then 'New incident or main call with incident


                                            @Html.TextBoxFor(Function(model) model.IncidentInfo.Suspect_Issue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "Suspect_Issue"})
                                            @Html.ValidationMessageFor(Function(model) model.IncidentInfo.Suspect_Issue, "", New With {.class = "text-danger"})

                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.Suspect_Issue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        End If

                                    end if
                                </div>

                                <div Class="col-md-2">
                                    <Label Class="TitleGrayOblique"></Label>
                                    @Html.Label("", "Workaround Applied", New With {.class = "TitleGrayOblique"})
                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.WorkaroundAppliedDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident


                                            @Html.DropDownListFor(Function(model) model.IncidentInfo.Workaround_Applied, New SelectList(ViewData("WorkAround"), "Value", "Text", Model.IncidentInfo.Workaround_Applied), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.WorkaroundAppliedDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        End If

                                    end if
                                </div>

                                <div Class="col-md-3">
                                    <Label Class="TitleGrayOblique"></Label>
                                    @Html.Label("", "Number of Impacted Users/Workstations", New With {.class = "TitleGrayOblique"})

                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.ImpactedNo, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Then 'New incident or main call with incident

                                            @Html.TextBoxFor(Function(model) model.IncidentInfo.ImpactedNo, New With {.Class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                            @Html.ValidationMessageFor(Function(model) model.IncidentInfo.ImpactedNo, "", New With {.class = "text-danger"})

                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.ImpactedNo, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                        End If
                                    end if

                                </div>

                            </div>

                            <div Class="row">
                                <div Class="col-md-4">


                                    <ul class="tooltip-end">
                                        <li>
                                            <Label Class="TitleGrayOblique">Replication*</Label>

                                        </li>
                                        <li>
                                            &nbsp;&nbsp;<span style="color:red !important;"><span id="probTypeError"></span></span>
                                            &nbsp;&nbsp;@Html.ValidationMessageFor(Function(model) model.IncidentInfo.Incident_Replication, String.Empty, New With {.style = "color:red;!important"})
                                        </li>
                                    </ul>
                                    @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                        @Html.DisplayFor(Function(model) model.IncidentInfo.IncidentReplicationDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                    Else
                                        @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident

                                            @Html.DropDownListFor(Function(model) model.IncidentInfo.Incident_Replication, New SelectList(ViewData("IncidentReplication"), "ID", "Desc", Model.IncidentInfo.Incident_Replication), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .required = True})
                                        ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.IncidentReplicationDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        End If
                                    end if
                                </div>
                                <div Class="col-md-4">
                                    <br>
                                    @Code
                                        Dim showtransfer = "block"

                                        If (Model.IncidentInfo.IncidentID > 0) Then
                                            showtransfer = "none"

                                        End If


                                    End Code

                                    <div class="row" id="TransfertoR&DBugs" style="display:@showtransfer;">

                                        <label>
                                            @Html.CheckBoxFor(Function(model) model.IncidentInfo.TransfertoRDBugs, New With {.id = "TransfertoR&DBugs"})
                                            <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Transfer to R&D Bugs</span>
                                        </label>

                                    </div>
                                </div>

                            </div>

                            @Code
                                Dim showIncidentReject = "block"
                                Dim showIncidentRejectButtonText = "glyphicon glyphicon-chevron-down"
                                If (Model.IncidentInfo.Reject_Reason Is Nothing) Then
                                    showIncidentReject = "none"
                                    showIncidentButtonText = "glyphicon glyphicon-chevron-right"
                                End If


                            End Code

                            <div class="row" id="DivRejection" style="display:@showIncidentReject;">




                                <h4>Incident Denied</h4>
                                <div class="row">


                                    <div class="col-md-4">
                                        @Html.Label("", "Reason for Denial", New With {.class = "TitleGrayOblique"})

                                        @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                            @Html.DisplayFor(Function(model) model.IncidentInfo.RejectReasonDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                        Else
                                            @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Or Model.CloseCall = False Or Model.IncidentInfo.Status <> 4 Then 'New incident or main call with incident

                                                @Html.DropDownListFor(Function(model) model.IncidentInfo.Reject_Reason, New SelectList(ViewData("IncidentRejection"), "ID", "Desc", Model.IncidentInfo.Reject_Reason), "Select", New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "Reject_Reason"})
                                            ElseIf Model.RandDList(0).ExhibitsIncident IsNot Nothing Then
                                                @Html.DisplayFor(Function(model) model.IncidentInfo.RejectReasonDesc, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                            End If
                                        end if
                                    </div>

                                    @Code
                                        Dim showIncidentNumber = "block"

                                        If (Model.IncidentInfo.Reject_Reason <> "1") Then
                                            showIncidentNumber = "none"

                                        End If


                                    End Code
                                    <div id="DivIncidentNumber" style="display:@showIncidentNumber;">
                                        <div class="col-md-2">
                                            @Html.Label("", "Incident Number", New With {.class = "TitleGrayOblique"})
                                            @if Model.CloseCall = True Or Model.IncidentInfo.Status = 4 Then
                                                @Html.DisplayFor(Function(model) model.IncidentInfo.Duplicate_ofIncident, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                            Else

                                                @if (Model.RandDList(0).IncidentID IsNot Nothing) Or (Model.RandDList(0).IncidentID Is Nothing And Model.RandDList(0).ExhibitsIncident Is Nothing) Then 'New incident or main call with incident


                                                    @Html.TextBoxFor(Function(model) model.IncidentInfo.Duplicate_ofIncident, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus", .id = "Duplicate_ofIncidentId"})
                                                ElseIf Not Model.RandDList(0).ExhibitsIncident Is Nothing Then
                                                    @Html.DisplayFor(Function(model) model.IncidentInfo.Duplicate_ofIncident, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})

                                                End If
                                            end if
                                        </div>
                                    </div>
                                    @Html.HiddenFor(Function(model) model.IncidentInfo.Rejected_byRD_By)
                                    @Html.HiddenFor(Function(model) model.IncidentInfo.Rejected_byRD_Dt)
                                    @Html.HiddenFor(Function(model) model.IncidentInfo.SubmittedToRD_By)
                                    @Html.HiddenFor(Function(model) model.IncidentInfo.SubmittedToRD_Dt)
                                    @Html.HiddenFor(Function(model) model.IncidentInfo.StatusToRDFirstTime)

                                </div>



                            </div>



                        </div>
                        @Html.HiddenFor(Function(model) model.IncidentInfo.IncidentID)
                    </div>

                </div>
            </div>



            @*Incident info*@



            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showBillingDisplay = "block"
                        Dim showBillingButtonText = "glyphicon glyphicon-chevron-down"
                        If Session("ShowBilling") = "False" Then
                            showBillingDisplay = "none"
                            showBillingButtonText = "glyphicon glyphicon-chevron-right"
                        End If
                    End Code
                    <div class="panel-heading well well-sm TitleGrayOblique" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingBillingInfo" onclick="javascript:ShowPanel(btnBillingInfo,billingInfo)">
                        <label>
                            <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                <span id="btnBillingInfo" class="@showBillingButtonText" style="color:#428bca;"></span>
                                &nbsp;Billing Information
                            </span>
                        </label>
                    </div>
                    <div class="panel-body" id="billingInfo" style="display:@showBillingDisplay;">
                        <div class="row">
                            <div class="col-md-12">
                                <span style="color:red !important;"><span id="billingError"></span></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>
                                    @Html.CheckBoxFor(Function(model) model.BillingList(0).Billable)
                                    <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Billable</span>
                                </label>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    @Html.CheckBoxFor(Function(model) model.BillingList(0).PrePaid)
                                    <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Pre-Paid</span>
                                </label>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    @Html.CheckBoxFor(Function(model) model.BillingList(0).BillActualHours)
                                    <span class="TitleGrayOblique checkbox-label" style="font-weight:bold !important;">&nbsp;Bill Actual Hours</span>
                                </label>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.BillingList(0).ProjectedAmtDue, "Projected Amount Due", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.BillingList(0).ProjectedAmtDue, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                                @Html.ValidationMessageFor(Function(model) model.BillingList(0).ProjectedAmtDue, "", New With {.class = "text-danger"})

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <span class="TitleGrayOblique">
                                    @Html.LabelFor(Function(model) model.BillingList(0).BillingNotes, "Billing Instructions/Notes")
                                </span>
                                @Html.TextBoxFor(Function(model) model.BillingList(0).BillingNotes, New With {.class = "ControlsFormat ControlwidthExtraPlus "})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.BillingList(0).PO_Dt, "PO Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker9'>
                                    @Code
                                        Dim poDate As String = ""
                                        If Not Model.BillingList Is Nothing Then
                                            If Not Model.BillingList(0).PO_Dt Is Nothing Then
                                                poDate = Model.BillingList(0).PO_Dt
                                            End If
                                        End If
                                    End Code
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="poDtText" value="@poDate" />
                                    @Html.HiddenFor(Function(model) model.BillingList(0).PO_Dt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.BillingList(0).Billing_Dt, "Billing Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker10'>
                                    @Code
                                        Dim billingDate As String = ""
                                        If Not Model.BillingList Is Nothing Then
                                            If Not Model.BillingList(0).Billing_Dt Is Nothing Then
                                                billingDate = Model.BillingList(0).Billing_Dt
                                            End If
                                        End If
                                    End Code
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="billingDtText" value="@billingDate" />
                                    @Html.HiddenFor(Function(model) model.BillingList(0).Billing_Dt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.BillingList(0).Discount, "Discount", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.BillingList(0).Discount, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-3">
                                @Html.LabelFor(Function(model) model.BillingList(0).TotalAmtBilled, "Total Amount Billed", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.BillingList(0).TotalAmtBilled, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <span class="TitleGrayOblique">
                                    @Html.LabelFor(Function(model) model.BillingList(0).BillingStatus, "Billing Status")
                                </span>
                                @Html.TextBoxFor(Function(model) model.BillingList(0).BillingStatus, New With {.class = "ControlsFormat ControlwidthExtraPlus "})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                @Html.LabelFor(Function(model) model.BillingList(0).DeliveryInvoice, "Delivery Invoice", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.BillingList(0).DeliveryInvoice, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-4">
                                @Html.LabelFor(Function(model) model.BillingList(0).PrePayInvoice, "Pre-Paid Invoice", New With {.class = "TitleGrayOblique"})
                                @Html.TextBoxFor(Function(model) model.BillingList(0).PrePayInvoice, New With {.class = "dropdownFormat ControlwidthEdit ControlwidthExtraPlus"})
                            </div>
                            <div class="col-md-4">
                                @Html.LabelFor(Function(model) model.BillingList(0).Paid_Dt, "Paid Date", New With {.class = "TitleGrayOblique"})
                                <div class='input-group date' id='datetimepicker11'>
                                    @Code
                                        Dim paidDate As String = ""
                                        If Not Model.BillingList Is Nothing Then
                                            If Not Model.BillingList(0).Paid_Dt Is Nothing Then
                                                paidDate = Model.BillingList(0).Paid_Dt
                                            End If
                                        End If
                                    End Code
                                    <input type="text" class="dropdownFormat ControlwidthEdit ControlwidthExtraPlus" id="paidDtText" value="@paidDate" />
                                    @Html.HiddenFor(Function(model) model.BillingList(0).Paid_Dt)
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    @Code
                        Dim showActionsDisplay = "block"
                        Dim showActionsButtonText = "glyphicon glyphicon-chevron-down"
                        If Session("ShowActions") = "False" Then
                            showActionsDisplay = "none"
                            showActionsButtonText = "glyphicon glyphicon-chevron-right"
                        End If
                    End Code
                    <div class="panel-heading well well-sm" style="background-color:#ff8500; padding:5px !important; height:42px !important; cursor:pointer;" id="headingActionSection" onclick="javascript:ShowPanel(btnActionSection,actionSection)">
                        <label>
                            <span class="TitleSubTitleOrange" style="padding:0px !important; color:white; cursor:pointer;">
                                <span id="btnActionSection" class="@showActionsButtonText" style="color:#428bca;"></span>
                                &nbsp;Action Section
                            </span>
                        </label>
                    </div>
                    <div class="panel-body" id="actionSection" style="display:@showActionsDisplay;">
                        @Code
                            Dim iSTAR = Session("SmallTAR")
                            Dim iSTAC = Session("SmallTAC")
                            Dim iLTAR = Session("LargeTAR")
                            Dim iLTAC = Session("LargeTAC")
                            If iLTAR = 0 Then
                                iLTAR = 4
                            End If
                        End Code
                        <div class="row">
                            <div class="col-md-12">
                                @Html.LabelFor(Function(model) model.Internal_Notes, "Internal Notes", New With {.class = "TitleGrayOblique"})
                                @Html.TextAreaFor(Function(model) model.Internal_Notes, New With {.class = "ControlsFormat ControlwidthExtraPlus", .rows = iLTAR, .cols = iLTAC, .onKeyDown = "this.onEnterPress"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="tooltip-end">
                                    <li>
                                        @Html.LabelFor(Function(model) model.Cust_Notes, "Customer Actions", New With {.class = "TitleGrayOblique"})
                                    </li>
                                    <li>
                                        &nbsp;&nbsp;<span style="color:red !important;"><span id="notesError"></span></span>
                                    </li>
                                </ul>
                                @Html.TextAreaFor(Function(model) model.Cust_Notes, New With {.class = "ControlsFormat ControlwidthExtraPlus", .rows = iLTAR, .cols = iLTAC, .onKeyDown = "this.onEnterPress"})
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label class="TitleGrayOblique"><span class="TitleGrayOblique" style="color:#2F4CA0; font-weight:bold;">*</span> - Required Field</label><br />
                    @If Model.SplitCallCount <> 0 Then
                        If Model.Parent = Model.SIID Or Model.SplitCallMode = 3 Then
                            @<input name="CopyChildNotes" type="checkbox" id="CopyChildNotes" />
                            @<span Class="TitleGrayOblique checkbox-label">@Html.Label("Add Notes to Children Calls")</span>
                            @<br />
                        End If
                    End If
                    <input type="submit" id="BtnSave" value="Save" style="display: none;" />
                    <input type="button" class="saveButton" value="Save" id="btnSaveVisible" onclick="javascript: Save();" />
                    @Html.HiddenFor(Function(model) model.Contact_FirstName)
                    @Html.HiddenFor(Function(model) model.Contact_LastName)
                    @Html.HiddenFor(Function(model) model.Contact_Phone1)
                    @Html.HiddenFor(Function(model) model.Contact_Phone2)
                    @Html.HiddenFor(Function(model) model.ContactEmail)
                    @Html.HiddenFor(Function(model) model.CentralTime)
                    @Html.HiddenFor(Function(model) model.GS_Version)
                    @Html.HiddenFor(Function(model) model.UCID)
                    @Html.HiddenFor(Function(model) model.UID)
                    @Html.HiddenFor(Function(model) model.CallTypeID)
                    @Html.HiddenFor(Function(model) model.ActionID)
                    @Html.HiddenFor(Function(model) model.EmpID)
                    @Html.HiddenFor(Function(model) model.VerID)
                    @Html.HiddenFor(Function(model) model.Call_Ver)
                    @Html.HiddenFor(Function(model) model.Qid)
                    @Html.HiddenFor(Function(model) model.Qid_DB)
                    @Html.HiddenFor(Function(model) model.ProblemID)
                    @Html.HiddenFor(Function(model) model.InternalStatus)
                    @Html.HiddenFor(Function(model) model.sLastProblemType)
                    @Html.HiddenFor(Function(model) model.Call_Ver)
                    @Html.HiddenFor(Function(model) model.EntryMethod)
                    @Html.HiddenFor(Function(model) model.SIID)
                    @*@Html.HiddenFor(Function(model) model.Title)*@
                    @Html.HiddenFor(Function(model) model.Owner)
                    @Html.HiddenFor(Function(model) model.BillingList(0).SIBID)
                    @Html.HiddenFor(Function(model) model.BillingList(0).SIID)
                    @Html.HiddenFor(Function(model) model.RandDList(0).SIRDID)
                    @Html.HiddenFor(Function(model) model.RandDList(0).SIID)
                    @Html.HiddenFor(Function(model) model.CloudList(0).SCID)
                    @Html.HiddenFor(Function(model) model.ContactName)

                    @Html.HiddenFor(Function(model) model.QACreated)
                    @Html.HiddenFor(Function(model) model.IsCloudRequest)
                    @Html.Hidden("bInternational", ViewData("bInternational"))
                    @Html.Hidden("hdnTLGrp", Session("iTLGrp"), New With {.id = "tlGrp"})
                    @Html.Hidden("hdnAdmin", Session("bAdmin"), New With {.id = "bAdmin"})
                    @Html.Hidden("DateNow", Now.ToString("MM.dd.yyyy"), New With {.id = "DateNow"})
                    @Html.HiddenFor(Function(model) model.ProblemID, New With {.id = "hdnProbID_Orig", .name = "hdnProbID_Orig"})
                    @Html.HiddenFor(Function(model) model.CallTypeID, New With {.id = "currentCallType", .name = "currentCallType"})
                    @Html.HiddenFor(Function(model) model.CloudList(0).RequestDate, New With {.id = "hdnRequestDate_Orig", .name = "hdnRequestDate_Orig"})
                    <input type="hidden" id="TimeNow" value="@Now.ToShortTimeString" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="grid-padding">
                        <div>
                            <ul class="tooltip-end">
                                <li>
                                    <img src="~/Images/Calls/open_32x32.png" width="20" height="20" />
                                    <span class="TitleGrayOblique left-padding">Call Attachments&nbsp;&nbsp;</span>
                                </li>
                                <li>
                                    <span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" style="cursor:pointer;" aria-hidden="true" title="Only one file may be added with the initial entry of the call, if you have multiple files, you may zip them and attach the zip, or add one file and add the rest once the call has been created."></span>
                                </li>
                            </ul>
                            <input type="File" name="File" id="fileInput" size="50" style="width:100%;" />
                            <button onclick="SaveRefreshFile()" type="button">Upload File</button>
                            <input type="hidden" id="fileRowCount" value="@Model.BinaryList.Count" />
                        </div>
                        <div id="DivRefreshFiles">
                            @Html.Action("CallFilesPartial", "Calls", New With {.siid = Model.SIID})
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="grid-padding">
                        <div>
                            <p class="TitleBlack">
                                <img src="~/Images/Calls/breaks_column_32x32.png" width="20" height="20" />
                                <span class="TitleGrayOblique left-padding">Action History</span>
                            </p>
                        </div>
                        @*<div>
                                @Html.DevExpress().Button(Sub(btn)
                                                              btn.Name = "btnExportToCSV"
                                                              btn.Text = "Export to CSV"
                                                              btn.UseSubmitBehavior = True
                                                              btn.RouteValues = New With {Key .Controller = "Calls", Key .Action = "ExportActionPartial", Key .exportType = "CSV"}
                                                              btn.Images.Image.IconID = DevExpress.Web.ASPxThemes.IconID.ExportExporttocsv16x16gray
                                                              btn.ImagePosition = ImagePosition.Left
                                                          End Sub).GetHtml()

                                @Html.DevExpress().Button(Sub(btn)
                                                              btn.Name = "btnExportToXLS"
                                                              btn.Text = "Export to XLS"
                                                              btn.UseSubmitBehavior = True
                                                              btn.RouteValues = New With {Key .Controller = "Calls", Key .Action = "ExportActionPartial", Key .exportType = "XLS"}
                                                              btn.Images.Image.IconID = DevExpress.Web.ASPxThemes.IconID.ExportExporttoxls16x16gray
                                                              btn.ImagePosition = ImagePosition.Left
                                                          End Sub).GetHtml()

                                @Html.DevExpress().Button(Sub(btn)
                                                              btn.Name = "btnExportToXLSX"
                                                              btn.Text = "Export to XLSX"
                                                              btn.UseSubmitBehavior = True
                                                              btn.RouteValues = New With {Key .Controller = "Calls", Key .Action = "ExportActionPartial", Key .exportType = "XLSX"}
                                                              btn.Images.Image.IconID = DevExpress.Web.ASPxThemes.IconID.ExportExporttoxlsx16x16gray
                                                              btn.ImagePosition = ImagePosition.Left
                                                          End Sub).GetHtml()

                                @Html.DevExpress().Button(Sub(btn)
                                                              btn.Name = "btnExportToPDF"
                                                              btn.Text = "Export to PDF"
                                                              btn.UseSubmitBehavior = True
                                                              btn.RouteValues = New With {Key .Controller = "Calls", Key .Action = "ExportActionPartial", Key .exportType = "PDF"}
                                                              btn.Images.Image.IconID = DevExpress.Web.ASPxThemes.IconID.ExportExporttopdf16x16gray
                                                              btn.ImagePosition = ImagePosition.Left
                                                          End Sub).GetHtml()
                            </div>*@
                        <div id="DivRefresh">
                            @Html.Action("CallActionPartial", "Calls", New With {.siid = Model.SIID, .callType = "Internal"})
                        </div>
                        <input type="hidden" id="actionRowCount" value="@Model.ActionsCount" />
                    </div>
                </div>
            </div>
        </div>  End Using

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "phoneExt1Modal"
                                         settings.HeaderText = "Phone"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 Dim phone1 = Model.Contact_Phone1
                                                                 Dim phone1Ext = Model.Contact_Phone1Ext

                                                                 ViewContext.Writer.Write("<div><h4>")
                                                                 ViewContext.Writer.Write(phone1)
                                                                 ViewContext.Writer.Write("&nbsp;Ext.&nbsp;")
                                                                 ViewContext.Writer.Write(phone1Ext)
                                                                 ViewContext.Writer.Write("</h4></div>")
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "phoneExt2Modal"
                                         settings.HeaderText = "Alt. Phone"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 Dim phone2 = Model.Contact_Phone2
                                                                 Dim phone2Ext = Model.Contact_Phone2Ext

                                                                 ViewContext.Writer.Write("<div><h4>")
                                                                 ViewContext.Writer.Write(phone2)
                                                                 ViewContext.Writer.Write("&nbsp;Ext.&nbsp;")
                                                                 ViewContext.Writer.Write(phone2Ext)
                                                                 ViewContext.Writer.Write("</h4></div>")
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "callWatchModal"
                                         settings.HeaderText = "Call Watch List"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 If Not Model.AllActionsList Is Nothing Then
                                                                     For i As Integer = 0 To Model.CallWatchList.Count - 1
                                                                         Dim empEmail As String = Model.CallWatchList(i).Emp_Email
                                                                         Dim refNo As String = Model.RefNo
                                                                         Dim empName As String = Model.CallWatchList(i).Emp_Name
                                                                         Dim title As String = Model.Title
                                                                         Dim url As String = "mailto:" + empEmail + "?subject=" + title.Replace("&", "%26") + " || GSRX-" + refNo + "-GSRX"
                                                                         ViewContext.Writer.Write("<a href=""" + url + """>" + empName + "</a>")
                                                                         If i <> Model.CallWatchList.Count - 1 Then
                                                                             ViewContext.Writer.Write("<br />")
                                                                         End If
                                                                     Next
                                                                 End If
                                                             End Sub)
                                     End Sub).GetHtml()

    @Code
        Dim childrenCallTitle As String = ""
        If Model.Parent = Model.SIID Or Model.SplitCallMode = 3 Then
            childrenCallTitle = "Split Calls List"
        Else
            childrenCallTitle = "Parent Call"
        End If
    End Code
    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "chilrenCallsModal"
                                         settings.HeaderText = childrenCallTitle
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(900)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.SettingsAdaptivity.Mode = PopupControlAdaptivityMode.Always
                                         settings.SettingsAdaptivity.VerticalAlign = PopupAdaptiveVerticalAlign.WindowCenter
                                         settings.SettingsAdaptivity.HorizontalAlign = PopupAdaptiveHorizontalAlign.WindowCenter
                                         settings.SettingsAdaptivity.MaxWidth = Unit.Pixel(900)
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"
                                         settings.ScrollBars = ScrollBars.Auto

                                         settings.SetContent(Sub()
                                                                 ViewContext.Writer.Write(Html.Action("CallsChildrenViewPartial", "Calls", New With {.siid = Model.SplitCall_SIID, .iMode = Model.SplitCallMode, .sParent = Model.Parent}))
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "projectCallsModal"
                                         settings.HeaderText = "Project Calls"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 ViewContext.Writer.Write(Html.Action("CallsProjectViewPartial", "Calls", New With {.projectID = Model.RandDList(0).ProjectID}))
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "codersModal"
                                         settings.HeaderText = "Coders"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.Height = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ScrollBars = ScrollBars.Vertical
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 Html.DevExpress().CheckBoxList(Sub(cbl)
                                                                                                    cbl.Name = "codersList"
                                                                                                    cbl.Properties.ValueField = "EmpID"
                                                                                                    cbl.Properties.TextField = "FullName"
                                                                                                    cbl.Properties.ClientSideEvents.SelectedIndexChanged = "function(s,e) {SetCoderName(s,e)}"
                                                                                                    cbl.Properties.RepeatDirection = RepeatDirection.Vertical
                                                                                                    cbl.PreRender = Sub(sender, e)
                                                                                                                        Dim list As MVCxCheckBoxList = sender
                                                                                                                        For Each item As ListEditItem In list.Items
                                                                                                                            If Model.RandDList(0).Coders IsNot Nothing Then
                                                                                                                                For i As Integer = 0 To Model.RandDList(0).Coders.Count - 1
                                                                                                                                    If Model.RandDList(0).Coders(i).RD_EmpID = item.Value Then
                                                                                                                                        item.Selected = True
                                                                                                                                    End If
                                                                                                                                Next
                                                                                                                            End If
                                                                                                                        Next
                                                                                                                    End Sub
                                                                                                End Sub).BindList(Session("EmployeeList")).GetHtml()
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "testersModal"
                                         settings.HeaderText = "Testers"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.Height = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ScrollBars = ScrollBars.Vertical
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 Html.DevExpress().CheckBoxList(Sub(cbl)
                                                                                                    cbl.Name = "testersList"
                                                                                                    cbl.Properties.ValueField = "EmpID"
                                                                                                    cbl.Properties.TextField = "FullName"
                                                                                                    cbl.Properties.ClientSideEvents.SelectedIndexChanged = "function(s,e) {SetTesterName(s,e)}"
                                                                                                    cbl.Properties.RepeatDirection = RepeatDirection.Vertical
                                                                                                    cbl.PreRender = Sub(sender, e)
                                                                                                                        Dim list As MVCxCheckBoxList = sender
                                                                                                                        For Each item As ListEditItem In list.Items
                                                                                                                            If Model.RandDList(0).Testers IsNot Nothing Then
                                                                                                                                For i As Integer = 0 To Model.RandDList(0).Testers.Count - 1
                                                                                                                                    If Model.RandDList(0).Testers(i).RD_EmpID = item.Value Then
                                                                                                                                        item.Selected = True
                                                                                                                                    End If
                                                                                                                                Next
                                                                                                                            End If
                                                                                                                        Next
                                                                                                                    End Sub
                                                                                                End Sub).BindList(Session("EmployeeList")).GetHtml()
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "issueCallsModal"
                                         settings.HeaderText = "Calls With Same Issue"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(900)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 ViewContext.Writer.Write(Html.Action("CallsIssuesViewPartial", "Calls", New With {.issueNo = Model.RandDList(0).ExhibitsIssue}))
                                                             End Sub)
                                     End Sub).GetHtml()

    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "contactNameChange"
                                         settings.HeaderText = "Change Contact Name"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(900)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 ViewContext.Writer.Write(Html.Action("ChangeContactViewPartial", "Calls", New With {.siid = Model.SIID}))
                                                             End Sub)
                                     End Sub).GetHtml()


    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "versionDateModal"
                                         settings.HeaderText = "Date GSS Version Loaded"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(300)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 If ViewBag.LastUpdateVer IsNot Nothing Then
                                                                     Dim lastDate = CDate(ViewBag.LastUpdateVer.ToString()).ToShortDateString()

                                                                     ViewContext.Writer.Write("<div><h4>")
                                                                     ViewContext.Writer.Write(lastDate)
                                                                     ViewContext.Writer.Write("</h4></div>")
                                                                 End If
                                                             End Sub)
                                     End Sub).GetHtml()


    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "popupCallEmail"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = False
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.SettingsAdaptivity.Mode = PopupControlAdaptivityMode.Always
                                         settings.SettingsAdaptivity.VerticalAlign = PopupAdaptiveVerticalAlign.WindowCenter
                                         settings.SettingsAdaptivity.HorizontalAlign = PopupAdaptiveHorizontalAlign.WindowCenter
                                         settings.Width = System.Web.UI.WebControls.Unit.Pixel(900)
                                         settings.Height = System.Web.UI.WebControls.Unit.Pixel(500)
                                         settings.AutoUpdatePosition = True
                                         settings.Width = Unit.Pixel(500)
                                         settings.AutoUpdatePosition = True
                                         settings.ScrollBars = ScrollBars.Vertical
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"
                                         settings.SettingsAdaptivity.MaxWidth = Unit.Pixel(800)
                                         settings.SettingsAdaptivity.MaxHeight = Unit.Pixel(600)

                                         settings.SetContent(Sub()
                                                                 ViewContext.Writer.Write("<div id=""callEmail""></div>")
                                                             End Sub)

                                     End Sub).GetHtml()


    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "modalFileViewer"
                                         settings.HeaderText = "Viewer"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         settings.AllowResize = True
                                         settings.ResizingMode = ResizingMode.Live
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.SettingsAdaptivity.Mode = PopupControlAdaptivityMode.Always
                                         settings.SettingsAdaptivity.VerticalAlign = PopupAdaptiveVerticalAlign.WindowCenter
                                         settings.SettingsAdaptivity.HorizontalAlign = PopupAdaptiveHorizontalAlign.WindowCenter
                                         settings.SettingsAdaptivity.MaxWidth = Unit.Pixel(900)
                                         'settings.SettingsAdaptivity.MinHeight = Unit.Pixel(400)
                                         settings.Width = Unit.Pixel(900)
                                         settings.AutoUpdatePosition = True
                                         settings.ScrollBars = ScrollBars.Auto
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"
                                         settings.EnableClientSideAPI = True
                                         settings.ClientSideEvents.Closing = "ClosingFileViewer"

                                         settings.SetContent(Sub()
                                                                 'ViewContext.Writer.Write("<div id=""modal_pdf"">")
                                                                 'ViewContext.Writer.Write("<embed align=""center"" id=""Viewerpdf"" width=""100%"" height=""700"" alt=""pdf"" pluginspage=""http://www.adobe.com/products/acrobat/readstep2.html"">")
                                                                 'ViewContext.Writer.Write("</div>")
                                                                 'ViewContext.Writer.Write("<div id=""modal_img"">")
                                                                 'ViewContext.Writer.Write("<img id=""modal_img_target"" class=""largeImg"">")
                                                                 'ViewContext.Writer.Write("</div>")
                                                                 ViewContext.Writer.Write("<div id=""callFileViewer""></div>")
                                                             End Sub)
                                     End Sub).GetHtml()


    @Html.DevExpress().PopupControl(Sub(settings)
                                         settings.Name = "IncidentCallsModal"
                                         settings.HeaderText = "Calls With Same Incident"
                                         settings.Modal = True
                                         settings.ShowHeader = True
                                         settings.ShowFooter = False
                                         settings.AllowDragging = True
                                         settings.ShowCloseButton = True
                                         settings.CloseOnEscape = True
                                         'settings.CloseAction = CloseAction.CloseButton
                                         settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                         settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                         settings.Width = Unit.Pixel(900)
                                         settings.AutoUpdatePosition = True
                                         settings.ShowPageScrollbarWhenModal = False
                                         settings.Styles.Header.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff8500")
                                         settings.Styles.Header.Font.Size = FontUnit.Large
                                         settings.Styles.Header.Font.Bold = True
                                         settings.Styles.Header.Font.Italic = True
                                         settings.Styles.Header.Font.Name = "OpenSans-Light,Arial,Helvetica,sans-serif"

                                         settings.SetContent(Sub()
                                                                 Dim sWhichValuetoUse As String = ""

                                                                 If Not String.IsNullOrEmpty(Model.RandDList(0).IncidentID) Then
                                                                     sWhichValuetoUse = Model.RandDList(0).IncidentID
                                                                 ElseIf Not String.IsNullOrEmpty(Model.RandDList(0).ExhibitsIncident) Then
                                                                     sWhichValuetoUse = Model.RandDList(0).ExhibitsIncident
                                                                 End If

                                                                 If Not String.IsNullOrEmpty(sWhichValuetoUse) Then
                                                                     ViewContext.Writer.Write(Html.Action("CallsIncidentsViewPartial", "Calls", New With {.sIncidentID = sWhichValuetoUse}))
                                                                 End If
                                                             End Sub)
                                     End Sub).GetHtml()


        Else

    @<script type="text/javascript">


         swal({
             title: "Your user profile does not have access to view this call. Please reach out to the ServiceWeb Team for additional information.",
             type: "warning",
             showCancelButton: false,
             confirmButtonColor: "#DD6B55",
             confirmButtonText: "Ok",

         },
             function (isConfirm) {
                 if (isConfirm) {

                     window.close();
                     window.open("/PersonalQueue/Index")

                     return false;
                 } else {

                     return true;
                 }
             });



    </script>

End If