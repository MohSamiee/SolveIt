const inputs = document.querySelectorAll(".otp-input");
const hiddenCode = document.getElementById("VerificationCode");
const mobile = document.getElementById("Mobile").value;
var expireTimeVal = document.getElementById("ExpireDateTime").value;
var expireTime = new Date(expireTimeVal);
var resendBtn = document.getElementById("resendBtn");

//var expireTime = new Date(expireTimeVal("yyyy - MM - ddTHH: mm: ss"));
var timerElement = document.getElementById("timer");

// Text Join
function updateCode() {
    let code = "";
    inputs.forEach(i => {
        code += i.value;
    });
    hiddenCode.value = code;
}

// Go to next box
inputs.forEach((input, index) => {
    input.addEventListener("input", function () {
        if (this.value.length === 1 && index < inputs.length - 1) {
            inputs[index + 1].focus();
        }
        updateCode();
    });

    input.addEventListener("keydown", function (e) {

        if (e.key === "Backspace" && this.value === "" && index > 0) {
            inputs[index - 1].focus();
        }
    });
});


// Handle Paste
inputs[0].addEventListener("paste", function (e) {
    let pasteData = e.clipboardData.getData("text");
    if (pasteData.length === inputs.length) {
        for (let i = 0; i < inputs.length; i++) {
            inputs[i].value = pasteData[i];
        }
        updateCode();
    }
});

//Handle the timer
var timer = setInterval(function () {

    var now = new Date();

    var distance = expireTime - now;

    if (distance <= 0) {

        clearInterval(timer);

        timerElement.style.display = "none";
        resendBtn.style.display = "inline-block";

        return;
    }

    var minutes = Math.floor(distance / 1000 / 60);
    var seconds = Math.floor((distance / 1000) % 60);

    timerElement.innerText = minutes + ":" + seconds.toString().padStart(2, '0');

}, 1000);



// Resend Activation Code
document.getElementById("resendBtn").addEventListener("click", function () {
    window.location.href = "/Account/ResendMobileActivationCode?mobile=" + mobile;
});