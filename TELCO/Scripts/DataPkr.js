$.datepicker.regional['es'] = {
    closeText: 'Aceptar',
    prevText: '<< Anterior',
    nextText: 'Siguiente >>',
    currentText: 'Fecha Actual',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};
$.datepicker.setDefaults($.datepicker.regional['es']);

$(document).ready(function () {
    $(function () {
        $(".date-picker").datepicker({
            dateFormat: 'dd-MM-yyyy',
            changeMonth: true,
            //yearRange: "-25:+0",
            yearRange: "2015:+0",
            changeYear: true,
            monthNamesShort: $.datepicker.regional["es"].monthNames,
            showButtonPanel: true,
            onClose: function (dateText, inst) {
                var day = $("#ui-datepicker-div .ui-datepicker-day :selected").val();
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).val($.datepicker.formatDate('dd-MM-yyyy', new Date(day, year, month, 1)));
            }
        });
        $(".date-picker").focus(function () {
            $(".ui-datepicker-calendar").hide();
            $("#ui-datepicker-div").position({
                my: "center top",
                at: "center bottom",
                of: $(this)
            });
        });
    });
});