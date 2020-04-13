(function(){

    // Initialization
    function initCommon() {
        $("input[name=shippingSameAsBilling]").on("click", function () {
            showHideShippingInfo(true);
        });

        $("#acceptTerms").on("click", enableDisableContinueButton);
    }
    
    function showHideShippingInfo(clearValues)
    {
        var hideShippingInfo = $("input[name=shippingSameAsBilling]").is(":checked");
        if (hideShippingInfo) {
            $("#shipping-info").hide();
        } else {
            if (clearValues) {
                //$("input[type=text][name^=shipping]").val("");
            }
            $("#shipping-info").show();
        }
    }

    function enableDisableContinueButton() {
        var enableContinueButton = $("#acceptTerms").is(":checked");
        if (enableContinueButton) {
            $("#continue-disabled").hide();
            $("#continue").show();
        } else {
            $("#continue-disabled").show();
            $("#continue").hide();
        }
    }

    initCommon();
})();


