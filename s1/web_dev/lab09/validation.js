/* write functions that define the action for each event */
function validate() {
	var sid = document.getElementById("sid").value;
	var pwd1 = document.getElementById("pwd1").value;
	var pwd2 = document.getElementById("pwd2").value;
	var uname = document.getElementById("uname").value;
	var genm = document.getElementById("genm").checked;
	var genf = document.getElementById("genf").checked;

	var errMsg = "";					/* stores the error message */
	var result = true;					/* assumes no errors */
	var pattern = /^[a-zA-Z ]+$/;		/* regular expression for letters and spaces only */
	var lowPattern = /[a-z]/;			/* regular expression for lowercase letters */
	var upPattern = /[A-Z]/;			/* regular expression for uppercase letters */
	var pdw1Char;						/* stores the current character position for pwd1 */
	var lC = 0;							/* stores amount of lowercase letters in pwd1 */
	var uC = 0;							/* stores amount of uppercase letters in pwd1 */

	/* Rule 1, check if all required inputs have value */
	if (sid == "") {
		errMsg += "Please enter a User ID. \n";
	}
	if (pwd1 == "") {
		errMsg += "Please enter a Password. \n";
	}
	if (pwd2 == "") {
		errMsg += "Please re-type your Password. \n";
	}
	if (uname == "") {
		errMsg += "Please enter your Username. \n";
	}
	if ((genm == "") && (genf == "")) {
		errMsg += "Please select your gender. \n";
	}
	
	/* Rule 2, check if the user ID contains an @ symbol  */
	if (sid.indexOf("@") == 0) {
		errMsg += "User ID cannot start with an @. \n";
	}
	if (sid.indexOf("@") < 0) {
		errMsg += "Please include an @ in your User ID. \n";
	}
	
	/* Rule 3, check if password and retype password are the same */
	if (pwd1 != pwd2) {
		errMsg += "Passwords do not match.\n";
	}
	
	/* Rule 4, check if user name contains only letters and spaces */
	if (! uname.match (pattern)) {
		errMsg += "Username cannot contain symbols.\n";
	}

	/* Rule 5, check if Password contains at least 8 digits */
	if (pwd1.length < 8) {
		errMsg += "Password must be at least 8 digits. \n";
	}

	/* Rule 6, check if Password contains at least 1 capital and lowercase letter */
	for (let i = 0; i <= pwd1.length;) {
		pdw1Char = pwd1.charAt(i);
		if (pdw1Char.match (lowPattern)) {
			lC++;
		}
		if (pdw1Char.match (upPattern)) {
			uC++;
		}

		i++;
	}
	if (lC == 0) {
		errMsg += "Please include at least 1 lowercase letter in your Password.\n";
	}
	if (uC == 0) {
		errMsg += "Please include at least 1 uppercase letter in your Password.\n";
	}

	/* Display error message any error(s) is/are detected */
	if (errMsg != "") {
		alert (errMsg);
		result = false;
	} 
	return result;
}

/* link HTML elements to corresponding event function */
function init () {
	/* link the variables to the HTML elements */
  var regForm = document.getElementById("regform");

	/* assigns functions to corresponding events */
  regForm.onsubmit = validate;
}

/* execute the initialisation function once the window*/
window.onload = init;