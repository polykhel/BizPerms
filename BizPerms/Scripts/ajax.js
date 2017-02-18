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
});