$(document).ready(function () {
    ChangeCardTypeIcon();
});

$("#Payment_CardNumber").on('input', function () {
    ChangeCardTypeIcon();
});

function ChangeCardTypeIcon() {
    var cardType = IsValidCreditCardNumber($("#Payment_CardNumber").val());

    $('#cardType').removeClass();
    $('#cardType').addClass(cardType);
}

function AmexCardnumber(cardNumber) {
    var regex = /^([34|37]{2})([0-9]{13})$/;
    return regex.test(cardNumber);
}

function VisaCardnumber(cardNumber) {
    var regex = /^([4]{1})([0-9]{12,15})$/;
    return regex.test(cardNumber);
}

function MasterCardnumber(cardNumber) {
    var regex = /^([51|52|53|54|55]{2})([0-9]{14})$/;
    return regex.test(cardNumber);
}

function DiscoverCardnumber(cardNumber) {
    var regex = /^([6011]{4})([0-9]{12})$/;
    return regex.test(cardNumber);
}

function DinerClubCardnumber(cardNumber) {
    var regex = /^([30|36|38]{2})([0-9]{12})$/;
    return regex.test(cardNumber);
}

function JCBCardnumber(cardNumber) {
    var regex = /(^(352)[8-9](\d{11}$|\d{12}$))|(^(35)[3-8](\d{12}$|\d{13}$))/;
    return regex.test(cardNumber);
}

function IsValidCreditCardNumber(cardNumber) {

    var cardType = null;

    if (VisaCardnumber(cardNumber)) {
        cardType = "visa";
    } else if (MasterCardnumber(cardNumber)) {
        cardType = "mastercard";
    } else if (AmexCardnumber(cardNumber)) {
        cardType = "amex";
    } else if (DiscoverCardnumber(cardNumber)) {
        cardType = "discover";
    } else if (DinerClubCardnumber(cardNumber)) {
        cardType = "diners-club";
    } else if (JCBCardnumber(cardNumber)) {
        cardType = "jcb";
    }

    return cardType !== null ? 'fab fa-cc-' + cardType + ' fa-2x' : 'fas fa-credit-card fa-2x';
}