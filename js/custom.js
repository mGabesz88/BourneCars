(function($) {
    "use strict";

    /* ==============================================
    STAT COUNT -->
    =============================================== */
    function count($this) {
        var current = parseInt($this.html(), 10);
        current = current + 1; /* Where 50 is increment */
        $this.html(++current);
        if (current > $this.data('count')) {
            $this.html($this.data('count'));
        } else {
            setTimeout(function() {
                count($this)
            }, 50);
        }
    }
    $(".stat_count").each(function() {
        $(this).data('count', parseInt($(this).html(), 10));
        $(this).html('0');
        count($(this));
    });

    /* ==============================================
      BACK TOP
      ===============================================
        jQuery(window).scroll(function(){
          if (jQuery(this).scrollTop() > 1) {
            jQuery('.dmtop').css({bottom:"20px"});
          } else {
            jQuery('.dmtop').css({bottom:"-100px"});
          }
        });
        jQuery('.dmtop').hover(function(){
          jQuery('html, body').animate({scrollTop: '0px'}, 800);
          return false;
        });
      =============================================== */

    /* ==============================================
      BACK TOP
      =============================================== */
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > 1) {
            jQuery('.dmtop').css({
                bottom: "20px"
            });
        } else {
            jQuery('.dmtop').css({
                bottom: "-100px"
            });
        }
    });
    jQuery('.dmtop').on(function() {
        jQuery('html, body').animate({
            scrollTop: '0px'
        }, 800);
        return false;
    });

    /* ==============================================
      TOOLTIP
      =============================================== */
    $('[data-toggle="tooltip"]').tooltip()

    /* ==============================================
      SELECT
      =============================================== */
    $('.selectpicker').selectpicker({
        style: 'btn-default',
        size: false
    });

    /* ==============================================
      ACCORDION
      =============================================== */
    var iconOpen = 'fa fa-minus',
        iconClose = 'fa fa-plus';

    $(document).on('show.bs.collapse hide.bs.collapse', '.accordion', function(e) {
        var $target = $(e.target)
        $target.siblings('.accordion-heading')
            .find('em').toggleClass(iconOpen + ' ' + iconClose);
        if (e.type == 'show')
            $target.prev('.accordion-heading').find('.accordion-toggle').addClass('active');
        if (e.type == 'hide')
            $(this).find('.accordion-toggle').not($target).removeClass('active');
    });

})(jQuery);