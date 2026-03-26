import { Loading } from '../../common/custom/scripts/loading.js';
import { ApiClient } from '../../common/custom/scripts/api-client.js';

window.clickOnInput = function (avatarInput) {
    var input = document.getElementById(avatarInput);
    input.click();
}

window.changeAvatar = async function (fileInput, actionUrl) {
    //Loading.start('#userInfo');
    Loading.start();

    const file = fileInput.files[0];
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
    debugger;
    if (!result.isSuccess) {
        displayModelStateErrors(result);
        return;
    }
    //showSuccessMessage("Success Message")
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

window.GetCities = async function (el) {
    var countryId = el.value;
    if (countryId !== '' && countryId.length) {
        const result =await ApiClient.get('/UserPanel/Profile/GetCities', { countryId: countryId }, '');
        console.log(result);
    } else {

    }
}