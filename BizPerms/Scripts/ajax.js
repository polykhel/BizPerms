function GetCities() {
    $.ajax({
        url: '/Json/cities',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '<option value="" selected disabled>- Select City -</option>';
                jQuery.each(data.cits, function (index, item) {
                    if (item.ProvinceId == $('#selectProvince option:selected').val()) {
                        options += ' <option value="' + item.Id + '">' + item.Name + "</option>";
                    }
                })
                $('#selectCity').html(options);
            }
        }
    });
}

function GetDistricts() {
    $.ajax({
        url: '/Json/districts',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('wrong');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '<option value="" selected disabled>- Select District -</option>';
                jQuery.each(data.dis, function (index, item) {
                    if (item.CityId == $('#selectCity option:selected').val()) {
                        options += ' <option value="' + item.Id + '">' + item.Name + "</option>";
                    }
                })
                $('#selectDistrict').html(options);
            }
        }
    });
}

function GetBarangays() {
    $.ajax({
        url: '/Json/barangays',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '<option value="" selected disabled>- Select Barangay -</option>';
                jQuery.each(data.bars, function (index, item) {
                    if (item.DistrictId == $('#selectDistrict option:selected').val()) {
                        options += ' <option value="' + item.Id + '">' + item.Name + "</option>";
                    }
                })
                $('#selectBarangay').html(options);
            }
        }
    });
}

function GetStreets() {
    $.ajax({
        url: '/Json/streets',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '<option value="" selected disabled>- Select Street -</option>';
                jQuery.each(data.sts, function (index, item) {
                    if (item.BarangayId == $('#selectBarangay option:selected').val()) {
                        options += ' <option value="' + item.Id + '">' + item.Name + "</option>";
                    }
                })
                $('#selectStreet').html(options);
            }
        }
    });
}

function GetFirstFees() {
    $.ajax({
        url: '/Json/fees',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '';
                var amount = 0.00;
                var totalAmount = 0.00;
                var status = "renew";
                if ($("input:radio[name='isNew']").is(':checked')) {
                    status = "new";
                }
                jQuery.each(data.fees, function (index, item) {
                    if (status == "new") {
                        if ($('#isCollected').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (1st) </td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            }
                        } else {
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (1st) </td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            } else if (item.StatusId == 1 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            }
                        }
                    } else if (status == "renew") {
                        if ($('#isCollected').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 2)  {
                                options += '<tr><td>' + item.Name + ' (1st) </td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            }
                        } else {
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (1st) </td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            } else if (item.StatusId == 2 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + item.Rate + '</td><td></td><td>' + item.Rate + '</td></tr>';
                                amount += parseFloat(item.Rate);
                                totalAmount += parseFloat(item.Rate);
                            }
                        }
                    }
                })
                $('#feeBody').html(options);
                $('#total').html("<tr><td>TOTAL</td><td>" + amount + "</td><td></td><td>" + totalAmount + "</td>");
            }
        }
    });
}

function GetSecondFees() {
    $.ajax({
        url: '/Json/fees',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '';
                var amount = 0.00;
                var totalAmount = 0.00;
                var status = "renew";
                if ($("input:radio[name='isNew']").is(':checked')) {
                    status = "new";
                }
                jQuery.each(data.fees, function (index, item) {
                    var rate = parseFloat(item.Rate);
                    if (status == "new") {
                        if ($('#isFirst').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (2nd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (1st - 2nd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 1 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    } else if (status == "renew") {
                        if ($('#isFirst').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 2)  {
                                options += '<tr><td>' + item.Name + ' (2nd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (1st - 2nd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 2 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    }
                })
                $('#feeBody').html(options);
                $('#total').html("<tr><td>TOTAL</td><td>" + amount + "</td><td></td><td>" + totalAmount + "</td>");
            }
        }
    });
}

function GetThirdFees() {
    $.ajax({
        url: '/Json/fees',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '';
                var amount = 0.00;
                var totalAmount = 0.00;
                var status = "renew";
                if ($("input:radio[name='isNew']").is(':checked')) {
                    status = "new";
                }
                jQuery.each(data.fees, function (index, item) {
                    var rate = parseFloat(item.Rate);
                    if (status == "new") {
                        if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "false") {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (2nd - 3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                        else {
                            rate *= 3;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (1st - 3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 1 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    } else if (status == "renew") {
                        if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "false") {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (2nd - 3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                        else {
                            rate *= 3;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (1st - 3rd) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 2 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    }
                })
                $('#feeBody').html(options);
                $('#total').html("<tr><td>TOTAL</td><td>" + amount + "</td><td></td><td>" + totalAmount + "</td>");
            }
        }
    });
}

function GetFourthFees() {
    $.ajax({
        url: '/Json/fees',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            if (data.isSuccess) {
                var options = '';
                var amount = 0.00;
                var totalAmount = 0.00;
                var status = "renew";
                if ($("input:radio[name='isNew']").is(':checked')) {
                    status = "new";
                }
                jQuery.each(data.fees, function (index, item) {
                    var rate = parseFloat(item.Rate);
                    if (status == "new") {
                        if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True" && $('#isThird').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True" && $('#isThird').val() == "false") {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (3rd - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "false") {
                            rate *= 3;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (2nd - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                        else {
                            rate *= 4;
                            if (item.isQuarterly && item.StatusId == 1) {
                                options += '<tr><td>' + item.Name + ' (1st - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 1 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    } else if (status == "renew") {
                        if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True" && $('#isThird').val() == "True") {
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "True" && $('#isThird').val() == "false") {
                            rate *= 2;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (3rd - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        } else if ($('#isFirst').val() == "True" && $('#isSecond').val() == "false") {
                            rate *= 3;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (2nd - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                        else {
                            rate *= 4;
                            if (item.isQuarterly && item.StatusId == 2) {
                                options += '<tr><td>' + item.Name + ' (1st - 4th) </td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            } else if (item.StatusId == 2 || item.StatusId == 3) {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td><td></td><td>' + rate + '</td></tr>';
                                amount += rate;
                                totalAmount += rate;
                            }
                        }
                    }
                })
                $('#feeBody').html(options);
                $('#total').html("<tr><td>TOTAL</td><td>" + amount + "</td><td></td><td>" + totalAmount + "</td>");
            }
        }
    });
}

function GetNewFees(url) {
    $.ajax({
        url: '/Json/' + url + 'fees',
        type: 'GET',
        dataType: 'json',
        error: function () {
            alert('<p>error.</p>');
        },
        success: function (data) {
            var quarter = $('#quarter').val();
            var lastQuarterPaid = $('#lastQuarterPaid').val();
            if (data.isSuccess) {
                var options = '';
                var amount = 0.00;
                jQuery.each(data.fees, function (index, item) {
                    var rate = parseFloat(item.Rate);
                    if (quarter == 1) {
                        if (item.isQuarterly) {
                            options += '<tr><td>' + item.Name + ' (1st) </td><td>' + rate + '</td></tr>';
                            amount += rate;
                        } else {
                            options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td></tr>';
                            amount += rate;
                        }
                    } else if (quarter == 2) {
                        if (lastQuarterPaid == 1) {
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (2nd) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid <= 0) {
                            rate *= 2;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (1st - 2nd) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            } else {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        }
                    } else if (quarter == 3) {
                        if (lastQuarterPaid == 2) {
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (3rd) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid == 1) {
                            rate *= 2;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (2nd - 3rd) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid <= 0) {
                            rate *= 3;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (1st - 3rd) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            } else {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        }
                    } else if (quarter == 4) {
                        if (lastQuarterPaid == 3) {
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (4th) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid == 2) {
                            rate *= 2;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (3rd - 4th) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid == 1) {
                            rate *= 3;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (2nd - 4th) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        } else if (lastQuarterPaid <= 0) {
                            rate *= 4;
                            if (item.isQuarterly) {
                                options += '<tr><td>' + item.Name + ' (1st - 4th) </td><td>' + rate + '</td></tr>';
                                amount += rate;
                            } else {
                                options += '<tr><td>' + item.Name + '</td><td>' + rate + '</td></tr>';
                                amount += rate;
                            }
                        }
                    }
                })
                $('#feeBody').html(options);
                $('#total').html("<tr><td>TOTAL</td><td>" + amount + "</td>");
                $('#txtPayableAmount').val(amount);
            }
        }
    });
}

$(function () {
    $('#selectProvince').on('change', function () {
        GetCities();
    })

    $('#selectCity').on('change', function () {
        GetDistricts();
    })

    $('#selectDistrict').on('change', function () {
        GetBarangays();
    })

    $('#selectBarangay').on('change', function () {
        GetStreets();
    })

    if ($('#completeRequirements').val() == "True") {
        $('#incompleteRequirements').hide();
        $('#btnCompute').click(function () {
            if ($('#first').is(':checked')) {
                GetFirstFees();
                $(":submit").removeAttr("disabled");
            }
            if ($('#second').is(':checked')) {
                GetSecondFees();
                $(":submit").removeAttr("disabled");
            }
            if ($('#third').is(':checked')) {
                GetThirdFees();
                $(":submit").removeAttr("disabled");
            }
            if ($('#fourth').is(':checked')) {
                GetFourthFees();
                $(":submit").removeAttr("disabled");
            }
        });
    } else {
        $('#incompleteRequirements').show();
        $('#myAssessmentForm :input').attr("disabled", "disabled");
    }

    if ($('#quarter').val() <= 0) {
        $('#warningSign').show();
        $('#myForm :input').attr("disabled", "disabled");
        $('#myModalToggle').attr("disabled", "disabled");
    } else {
        $('#warningSign').hide();

        $('#txtTenderedAmount').on('change', function () {
            var pay = parseFloat($('#txtPayableAmount').val());
            var ten = parseFloat($(this).val());
            var change = ten - pay
            $('#txtChangeAmount').val(change)
            if (change >= 0) {
                $('#postPayment').removeAttr('disabled');
            }
        });
        if ($('#isNewC').val() == "True") {
            GetNewFees("new");
        } else if ($('#isNewC').val() == "False") {
            GetNewFees("renew");
        }
    }
});