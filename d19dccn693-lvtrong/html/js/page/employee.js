$(document).ready(function() {
    //Default render
    let pageNumber = 1;
    loadData(pageNumber,"", "", "");
    //Add event
    var dialogMode = null;
    let pageSize = $(".the-table").data("pageSize");


    //Add Employee Button
    $("#bnt-addnew").click(function() {
        //Change mode
        dialogMode = "add";
        //Show dialog
        $("#employee-dialog").show();

        //Clear data
        $("#code-input").val("");
        $("#name-input").val("");
        $("#sex-input").val("");
        $("#date-input").val("");
        $("#cccd-input").val("");
        $("#provide-input").val("");
        $("#location-input").val("");
        $("#email-input").val("");
        $("#phone-input").val("");
        $("#pos-input").val("");
        $("#room-input").val("");
        $("#tax-input").val("");
        $("#salary-input").val("");
        $("#joindate-input").val("");
        $("#status-input").val("");
        //Call API
        $.ajax({
            type: "GET",
            url: "https://cukcuk.manhnv.net/api/v1/Customers/NewCustomerCode",
            success: function (response) {
                $("#number-input").val(response);
            }
        });

    })

    //Cancel dialog:
    $("#btn-cancel").click(function() {
        closePopup("#employee-dialog");
    })

    //Cancel popup:
    $(".cancel-btn").click(function() {
        off("#employee-popup");
    })


    //Double Click on Row to show Dialog:
    $(".the-table").on("dblclick", "tr" ,function() {
        //Change mode
        dialogMode = "edit"
        //Get object
        let employee = $(this).data("entity");
        updateId = employee.EmployeeId;
        $("#number-input").val(employee.EmployeeCode);
        $("#name-input").val(employee.FullName);
        $("#sex-input").val(employee.Gender);
        $("#date-input").val(convertDate(employee.DateOfBirth));
        $("#cccd-input").val(employee.IdentityNumber);
        $("#provide-input").val(employee.IdentityDate);
        $("#location-input").val(employee.IdentityPlace);
        $("#email-input").val(employee.Email);
        $("#phone-input").val(employee.PhoneNumber);
        $("#pos-input").val(employee.PositionId);
        $("#room-input").val(employee.DepartmentId);
        $("#tax-input").val(employee.PersonalTaxCode);
        $("#salary-input").val(employee.Salary);
        $("#joindate-input").val(employee.JoinDate);
        $("#status-input").val(employee.WorkStatus);

        //Show dialog
        $("#employee-dialog").show();
    })

    //Validate empty when input:
    $("input[must]").blur(function() {
        validateInputEmpty(this);
    })

    //Sort table
    $(".sort").click(function(){
        var table = $(this).parents("table").eq(0)
        var rows = table.find("tr:gt(0)").toArray().sort(comparer($(this).index()))
        this.asc = !this.asc
        if (!this.asc){rows = rows.reverse()}
        for (var i = 0; i < rows.length; i++){table.append(rows[i])}
    })
    //Delete button on mouse enter
    $(".the-table tbody").on("mouseenter", "tr",function() {
        turnOn(($(this).children().last().children()));
    })

    //Hide delete button on mouse out
    $(".the-table tbody").on("mouseleave", "tr",function() {
        off(($(this).children().last().children()));
    })

    //Delete call
    $(".the-table").on("click",".table-delete-btn", function() {
        var me = this;
        let employee = ($(me).parent().parent()).data("entity");
        popupOn(("#employee-popup"),"Xóa nhân viên", `Bạn có chắc muốn xóa nhân viên ${employee.FullName} không?`,"alert");
        $("#btn-delete").click(function() {
            sendDelete(employee.EmployeeId);
            closePopup("#employee-popup");
        });
    })

    //Save button:
    $("#btn-submit").click(function() {
        //Error Count
        var er = 0;
        //Number cannot be empty
        validationSendEmpty($("#number-input"), "Mã nhân viên không thể trông", er);
        //Name cannot be empty
        validationSendEmpty($("#name-input"), "Tên không thể trống", er);
        //Date cannot be future
        let dob = $("#date-input").val();
        if (dob) {
            date = new Date(dob);
            if (date > new Date()) {
                alert("Ngày sinh không thể lớn hơn hiện tại")
                er = er + 1;
            };
        }
        let provideDate = $("#provide-input").val();
        if (provideDate) {
            date = new Date (provideDate);
            if (date > new Date()) {
                alert("Ngày cấp không thể lớn hơn hiện tại");
                er = er + 1;
            }
        }
        let joinDate = $("#joindate-input").val();
        if (joinDate) {
            date = new Date (joinDate);
            if (date > new Date()) {
                alert("Ngày tham gia không thể lớn hơn hiện tại");
                er = er + 1;
            }
        }
        //CCCD must be number, cannot empty
        validationSendEmpty($("#cccd-input"), "Căn cước công dân không thể trống", er);
        validateNumber($("#cccd-input"), er);
        //Email form, cannot be empty
        validationSendEmpty($("#email-input"), "Email không thể trống", er);
        validateEmail($("#email-input"), er)
        //Phone must be number, cannot be empty
        validationSendEmpty($("#phone-input"), "Số điện thoại không thể trống", er);
        validateNumber($("#phone-input"), er)
        //Tax must be number
        validateNumber($("#tax-input"), er)
        //Salary must be number
        validateNumber($("#salary-input"), er)
        //Get data
        let code = $("#number-input").val();
        let fullName = $("#name-input").val();
        let gender = $("#sex-input").val();
        let cccd = $("#cccd-input").val();
        let location = $("#location-input").val();
        let mail = $("#email-input").val();
        let phone = $("#phone-input").val();
        let pos = $("#pos-input").val();
        let room = $("#room-input").val();
        let tax = $("#tax-input").val();
        let salary = $("#salary-input").val();
        let work = $("#status-input").val();
        if (er==0) {
            //Build object
            let employee = {
                "EmployeeCode" : code,
                "FullName" : fullName,
                "Gender": gender,
                "DateOfBirth" : dob,
                "PhoneNumber" : phone,
                "Email": mail,
                "IdentityNumber" : cccd,
                "IdentityDate" : provideDate,
                "IdentityPlace": location,
                "JoinDate": joinDate,
                "WorkStatus": work,
                "PersonalTaxCode": tax,
                "Salary": salary,
                "PositionId": pos,
                "DepartmentId": room
            }
            //Enable loading
            //Call API
            if (dialogMode=="add") {
                $.ajax({
                    type: "POST",
                    url: `https://cukcuk.manhnv.net/api/v1/Employees`,
                    data: JSON.stringify(employee),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        //Done loading
                        $("#employee-dialog").hide();
                        loadData();
                    },
                    error : {
                        function(response) {
                            debugger
                        }
                    }
                });
            } else if (dialogMode=="edit") {

                $.ajax({
                    type: "PUT",
                    url: `https://cukcuk.manhnv.net/api/v1/Employees/${updateId}`,
                    data: JSON.stringify(employee),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (response) {
                        //Done loading
                        $("#employee-dialog").hide();
                        loadData();
                    },
                    error : {
                        function(response) {
                            debugger
                        }
                    }
                });
            }
            
        } else {
            debugger
        }
    })
    //Page number on click:
    $(".page-number").click(function() {
        $(".page-number").removeClass("selected-btn");
        $(this).addClass("selected-btn");
        pageNumber = parseInt($(this).text());
        loadData(pageNumber,$("#search-field").val(),$("#department-select").val(),$("#slot-select").val());
    })
    //First button
    $(".first-btn").click(function() {
        $("#btn-1").click();
    })
    //Previous button
    $(".prev-btn").click(function() {
        if (pageNumber >1) {
            pageNumber -= 1;
            $(`#btn-${pageNumber}`).click();
        }
    })
    //Next button
    $(".next-btn").click(function() {
        if (pageNumber<$(".the-table").data("pageSize")) {
            pageNumber += 1;
            $(`#btn-${pageNumber}`).click();
        }
    })
    //Last button
    $(".last-btn").click(function () {
        $(`#btn-${$(".the-table").data("pageSize")}`).click();
    })
})

//Show target
function turnOn(target) {
    $(target).show();
}

//Hide target
function off(target) {
    $(target).hide();
}

//Check Input Empty
function validateInputEmpty(input) {
    let content = $(input).val();
    if (content == null || content === "") {
        $(input).addClass("error");
    } else {
        $(input).removeClass("error");
    }
}

//Check Send Empty
function validationSendEmpty(input, string, errorCount) {
    let content = $(input).val();
    if (content == null || content === "") {
        popupOn($("#employee-popup"), "Lỗi", string, "warning");
        $(errorCount) += 1;
    }
}

//Change null value to none
function removeNull (input) {
    if (input == null) {
        input = "";
    }
    
    return input;
}

//Validate Email
function validateEmail (input, errorCount) {
    let email = $(input).val();
    var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
    if (email) {
        if (regex.test(email)){

        } else {
            popupOn($("#employee-popup"), "Lỗi", "Sai định dạng Email", "warning");
            $(errorCount) += 1;
        }
    }

}

//Validate Number
function validateNumber (input, errorCount) {
    let number = $(input).val();
    var regex = /^\d+$/;
    if (number) {
        if (regex.test(number)) {

        } else {
            popupOn($("#employee-popup"), "Lỗi", "Sai định dạng số", "warning");
            $(errorCount) += 1;
        }
    }

}

//Load Data from API and clear Table
function loadData(pageNum, nameFilter, departmentFilter, positionFilter) {
    let pNumber = pageNum
    //Clear old data
    $("#table tbody").empty();

    //build object
    let page = {
        pageSize : 10,
        pageNumber : pNumber,
        employeeFilter : nameFilter,
        departmentId : departmentFilter,
        positionId : positionFilter
    }

    //Load data from API
    //1. Call API...
    $.ajax({
        type: "GET",
        url: "https://cukcuk.manhnv.net/api/v1/Employees/filter",
        data: page,
        success: function (response) {
            for (let i = response.TotalPage + 1; i < 10; i++) {
                $(`#btn-${i}`).hide();
            }
            for (const employee of response.Data) {
                let employeeCode = employee.EmployeeCode;
                let employeeName = employee.FullName;
                let employeeGender = employee.GenderName;
                let employeeDoB = employee.DateOfBirth;
                let employeePhone = employee.PhoneNumber;
                let employeeMail = employee.Email;
                let employeePos = employee.PositionName;
                let employeeRoom = employee.DepartmentName;
                let employeeSalary = employee.Salary;
                let employeeWork = employee.WorkStatus;
                let nDoB;
                let nSalary;
                //format data
                //date
                if (employeeDoB) {
                    date = new Date(employeeDoB);
                    let d = date.getDate();
                    d = d <10? `0${d}` : d;
                    let m = date.getMonth() +1; //Month start from 0 but we start from 1
                    m = m <10? `0${m}` : m;
                    let y = date.getFullYear();

                    nDoB = `${d}/${m}/${y}`;
                } else {
                    nDoB = "";
                }
                //money
                if (employeeSalary) {
                    nSalary = new Intl.NumberFormat('vi-VN', {style: 'currency', currency: 'VND'}).format(employeeSalary);
                } else {
                    nSalary = ""
                }
                
                //Build HTML
                var row = $(`<tr class="employee-row">
                            <td class="text-left">${employeeCode}</td>
                            <td class="text-left">${employeeName}</td>
                            <td class="text-left">${removeNull(employeeGender)}</td>
                            <td class="text-left">${nDoB}</td>
                            <td class="text-left">${removeNull(employeePhone)}</td>
                            <td class="text-left">${removeNull(employeeMail)}</td>
                            <td class="text-left">${removeNull(employeePos)}</td>
                            <td class="text-left">${removeNull(employeeRoom)}</td>
                            <td class="text-right">${nSalary}</td>
                            <td class="text-left">${removeNull(employeeWork)}</td>
                            <td class="table-delete-cell"><button class="btn table-delete-btn">Xóa</button></td>
                        </tr>`);
                row.data("entity", employee)
                //Binding data to UI
                $(".the-table tbody").append(row);          
            }
            $(".the-table").data("pageSize",response.TotalPage);


        }
    });

}

function sendDelete (targetId) {
    $.ajax({
        type: "DELETE",
        url: `https://cukcuk.manhnv.net/api/v1/Employees/${targetId}`,
        success: function (response) {
            loadData();
        }
    });
}

//Comparer for table sort
function comparer (input) {
    return function(a, b) {
        var valA = getValue(a, input), valB = getValue(b, input)
        return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB)
    }
}

//Get value from row
function getValue (row, input) {
    return $(row).children("td").eq(input).text();
}

//Convert date to form yyyy/mm/dd
function convertDate (input) {
    let date = input 
    if (date) {
        date = new Date(date);
        let d = date.getDate();
        d = d <10? `0${d}` : d;
        let m = date.getMonth() +1; //Month start from 0 but we start from 1
        m = m <10? `0${m}` : m;
        let y = date.getFullYear();
        return `${y}/${m}/${d}`;
    } else {
        return "";
    }
}