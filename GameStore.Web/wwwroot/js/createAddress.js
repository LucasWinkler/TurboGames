$(document).ready(function () {
    $('#Address_Country').on('change', function () {
        var countryInput = $('#Address_Country');
        var provinceInput = $('#provinceGroup > #Address_StateProvinceRegion');
        var provinceGroup = $('#provinceGroup');
        var stateRegionInput = $('#stateRegionGroup > #Address_StateProvinceRegion');
        var stateRegionGroup = $('#stateRegionGroup');

        if (countryInput.find(':selected').text() === 'Canada') {
            provinceGroup.removeClass('hidden');
            stateRegionGroup.addClass('hidden');
            provinceInput.removeAttr('disabled');
            stateRegionInput.attr('disabled', true);
        } else {
            provinceGroup.addClass('hidden');
            stateRegionGroup.removeClass('hidden');
            stateRegionInput.removeAttr('disabled');
            provinceInput.attr('disabled', true);
        }
    });
});