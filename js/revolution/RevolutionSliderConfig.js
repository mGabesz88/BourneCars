/* ==============================================
  REV SLIDER -->
  =============================================== */
var tpj = jQuery;
var revapi4;
tpj(document).ready(function () {
    if (tpj("#main_slider").revolution == undefined) {
        revslider_showDoubleJqueryError("#main_slider");
    }
    else {
        revapi4 = tpj("#main_slider").show().revolution({
            sliderType: "standard", sliderLayout: "auto", loops: false, delay: 7500, navigation: {
                keyboardNavigation: "off", keyboard_direction: "horizontal", mouseScrollNavigation: "off", onHoverStop: "on", touch: {
                    touchenabled: "on", swipe_threshold: 75, swipe_min_touches: 1, swipe_direction: "horizontal", drag_block_vertical: false
                }
                , arrows: {
                    style: "hephaistos", enable: true, hide_onmobile: false, hide_onleave: false, tmp: '<div class="arrow-holder"> </div>', left: {
                        h_align: "left", v_align: "center", h_offset: 28, v_offset: 32
                    }
                    , right: {
                        h_align: "right", v_align: "center", h_offset: 43, v_offset: 32
                    }
                }
                ,
            }
            , responsiveLevels: [2220, 1183, 975, 751], gridwidth: [1170, 970, 770, 480], gridheight: [700, 700, 700, 500], lazyType: "none", parallax: {
                type: "mouse", origo: "slidercenter", speed: 2000, levels: [2, 3, 4, 5, 6, 7, 12, 16, 10, 50],
            }
            , shadow: 0, spinner: "off", stopLoop: "off", stopAfterLoops: -1, stopAtSlide: -1, shuffle: "off", autoHeight: "off", hideThumbsOnMobile: "off", hideSliderAtLimit: 0, hideCaptionAtLimit: 0, hideAllCaptionAtLilmit: 0, debugMode: false, fallbacks: {
                simplifyAll: "off", nextSlideOnWindowFocus: "off", disableFocusListener: false,
            }
        }
        );
    }
}
);
/*ready*/