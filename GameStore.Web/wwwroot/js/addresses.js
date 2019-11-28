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

    $('#BillingAddress_Country').on('change', function () {
        var countryInput = $('#BillingAddress_Country');
        var provinceInput = $('#billingProvinceGroup #BillingAddress_StateProvinceRegion');
        var provinceGroup = $('#billingProvinceGroup');
        var stateRegionInput = $('#billingStateRegionGroup #BillingAddress_StateProvinceRegion');
        var stateRegionGroup = $('#billingStateRegionGroup');

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

    $('#ShippingAddress_Country').on('change', function () {
        var countryInput = $('#ShippingAddress_Country');
        var provinceInput = $('#shippingProvinceGroup #ShippingAddress_StateProvinceRegion');
        var provinceGroup = $('#shippingProvinceGroup');
        var stateRegionInput = $('#shippingStateRegionGroup #ShippingAddress_StateProvinceRegion');
        var stateRegionGroup = $('#shippingStateRegionGroup');

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
        }
    });

    const existingBillingCheckbox = $("#existingBillingAddress");
    existingBillingCheckbox.on('change', function () {
        if ($(this).is(":checked")) {
            $('#existingBillingGroup').removeClass('hidden');
            $('#newBillingGroup').addClass('hidden');
        }
    });

    const sameAddress = $("#IsSameAddress");
    sameAddress.on('change', function () {
        if ($(this).is(":checked")) {
            $('#shippingAddressGroup').addClass('hidden');
        } else {
            $('#shippingAddressGroup').removeClass('hidden');
        }
    });

    const newShippingCheckbox = $("#newShippingAddress");
    newShippingCheckbox.on('change', function () {
        if ($(this).is(":checked")) {
            $('#newShippingGroup').removeClass('hidden');
            $('#existingShippingGroup').addClass('hidden');
        }
    });

    const existingShippingCheckbox = $("#existingShippingAddress");
    existingShippingCheckbox.on('change', function () {
        if ($(this).is(":checked")) {
            $('#existingShippingGroup').removeClass('hidden');
            $('#newShippingGroup').addClass('hidden');
        }
    });
})();