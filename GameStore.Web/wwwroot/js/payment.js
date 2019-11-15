(function () {
    function AmexCardnumber(cardNumber) {
        var regex = /^3[47][0-9]{13}$/;
        return regex.test(cardNumber);
    }

    function VisaCardnumber(cardNumber) {
        var regex = /^4[0-9]{12}(?:[0-9]{3})?$/;
        return regex.test(cardNumber);
    }

    function MasterCardnumber(cardNumber) {
        var regex = /^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$/;
        return regex.test(cardNumber);
    }

    function DiscoverCardnumber(cardNumber) {
        var regex = /^6(?:011|5[0-9]{2})[0-9]{12}$/;
        return regex.test(cardNumber);
    }

    function DinerClubCardnumber(cardNumber) {
        var regex = /^3(?:0[0-5]|[68][0-9])[0-9]{11}$/;
        return regex.test(cardNumber);
    }

    function JCBCardnumber(cardNumber) {
        var regex = /^(?:2131|1800|35\d{3})\d{11}$/;
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

        return cardType !== null ? 'fab fa-cc-' + cardType + ' fa-2x text-primary' : 'fas fa-credit-card fa-2x';
    }

    function ChangeCardTypeIcon() {
        var cardType = IsValidCreditCardNumber($("#Payment_CardNumber").val());

        $('#cardType').removeClass();
        $('#cardType').addClass(cardType);
    }

    $("#Payment_CardNumber").on('input', function () {
        ChangeCardTypeIcon();
    });

    ChangeCardTypeIcon();
})();