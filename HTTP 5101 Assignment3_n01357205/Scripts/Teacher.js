window.onload = function () {
    var formhandle = document.forms.TeacherForm;
    formhandle.onsubmit = processForm;
    function processForm() {

        if (formhandle.TeacherFname.value == '') {
            formhandle.TeacherFname.style.borderColor = "#cd2026";
            formhandle.TeacherFname.focus();
            return false;
        }
        else {
            formhandle.TeacherFname.style.borderColor = "black";
        }

        if (formhandle.TeacherLname.value == '') {
            formhandle.TeacherLname.style.borderColor = "#cd2026";
            formhandle.TeacherLname.focus();
            return false;
        }
        else {
            formhandle.TeacherLname.style.borderColor = "black";
        }

        if (formhandle.EmployeeNumber.value == '') {
            formhandle.EmployeeNumber.style.borderColor = "#cd2026";
            formhandle.EmployeeNumber.focus();
            return false;
        }
        else {
            formhandle.EmployeeNumber.style.borderColor = "black";
        }

        if (formhandle.Salary.value == '') {
            formhandle.Salary.style.borderColor = "#cd2026";
            formhandle.Salary.focus();
            return false;
        }
        else {
            formhandle.Salary.style.borderColor = "black";
        }
    }//end of processForm
}