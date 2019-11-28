(function () {
    $('#Address_Country').on('change', function () {
        var countryInput = $('#Address_Country');
        var provinceInput = $('#provinceGroup #Address_StateProvinceRegion');
        var provinceGroup = $('#provinceGroup');
        var stateRegionInput = $('#stateRegionGroup #Address_StateProvinceRegion');
        var stateRegionGroup = $('#stateRegionGroup');

        if (countryInput.find(':selected').text() === 'Canada') {
            provinceGroup.removeClass('hidden');
            stateRegionGroup.addClass('hidden');
            provinceInput.prop('disabled', false);
            stateRegionInput.prop('disabled', true);
            stateRegionInput.val("");
        } else {
            provinceGroup.addClass('hidden');
            stateRegionGroup.removeClass('hidden');
            provinceInput.prop('disabled', true);
            stateRegionInput.prop('disabled', false);
            provinceInput.val("");
        }
    });

    const newBillingCheckbox = $("#newBillingAddress");
    newBillingCheckbox.on('change', function () {
        if ($(this).is(":checked")) {
            $('#newBillingGroup').removeClass('hidden');
            $('#existingBillingGroup').addClass('hidden');
            //$('#newBillingGroup').prop('disabled', false);
            //$('#existingBillingGroup').prop('disabled', true);
        }
    });

    const existingBillingCheckbox = $("#existingBillingAddress");
    existingBillingCheckbox.on('change', function () {
        if ($(this).is(":checked")) {
            $('#existingBillingGroup').removeClass('hidden');
            $('#newBillingGroup').addClass('hidden');
            //$('#newBillingGroup').prop('disabled', true);
            //$('#existingBillingGroup').prop('disabled', false);
        }
    });
})();