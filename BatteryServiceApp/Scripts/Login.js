function validateLogin() {
    if ($("#txtUsername").val() == "") {
        $('#usernameError').css("visibility", "initial");
        event.preventDefault();
        return false;
    }
    else
        $('#usernameError').css("visibility", "hidden");

    if ($("#txtPassword").val() == "") {
        $('#passwordError').css("visibility", "initial");
        event.preventDefault();
        return false;
    }
    else
        $('#usernameError').css("visibility", "hidden");

}