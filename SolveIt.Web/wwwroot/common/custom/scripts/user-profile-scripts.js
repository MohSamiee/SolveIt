function clickOnInput(avatarInput) {
    var input = document.getElementById(avatarInput);
    input.click();
}

async function changeAvatar(fileInput,actionUrl) {
    const file = fileInput.files[0];
    //var url = "/UserPanel/Home/ChangeUserAvatar"
    var returnUrl = "/UserPanel/Home/Index";
    if (!file) {
        alert("Please select a file");
        return;
    }


    const formData = new FormData();
    formData.append("userAvatar", file);

    const response = await fetch(actionUrl, {
        method: 'POST',
        body: formData
    });

    const result = await response.json();

    if (!result.isSuccess) {
        displayModelStateErrors(result);
        return;
    }
    showSuccessMessage("Success Message")
    goToUrl(returnUrl);
}

function goToUrl(url) {
    window.location.href = url;
}

function showSuccessMessage(message) {
    swal({
        title: "اعلان",
        text: message,
        icon: "success",
        button: "باشه"
    });
}

function displayModelStateErrors(result) {

    let errorSection = "";

    let errorList = [];

    if (result && (result.modelStateErrors)) {
        errorList = result.modelStateErrors || [];
    }
    document.querySelectorAll('.input-error').forEach(el => {
        el.classList.remove('input-error');
    });

    errorList.forEach(error => {
        const fieldName = error.ModelStateField || error.modelStateField || error.key;
        const errorMessage = error.ModelStateErrorMessage || error.modelStateErrorMessage || error.errorMessage;


        if (fieldName && errorMessage) {
            errorSection += errorMessage;
        }
    });
    swal({
        title: "اعلان",
        text: errorSection,
        icon: "error",
        button: "باشه"
    });
}