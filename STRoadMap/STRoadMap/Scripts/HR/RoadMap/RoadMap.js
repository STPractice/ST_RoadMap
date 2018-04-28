'use strict'

$(document).ready(function () {
    var open = false;
    $('#btn_showComments').click(function (e) {
        if (open == false) {
            $('#btn_showComments').css({
                'transform': 'rotateZ(180deg)',
                'color': '#fff',
                'background-color': '#63cdd7'
            }, 500);
            $('#chat').css({
                'display': 'block'
            });
            open = true;
        }
        else {
            $('#btn_showComments').css({
                'transform': 'rotateZ(0deg)',
                'color': '#000',
                'background': 'none'
            }, 500);
            $('#chat').css({
                'display': 'none'
            });
            open = false;
        }
    });


    var showlistOfCheckpoints = false;
    $('#roadMap').click(function (e) {
        if (showlistOfCheckpoints == false) {
            $('#listOfCheckpoints').css({
                'display': 'block',
                'position': 'absolute',
                'background-color': '#fff',
                'z-index': '1'
            });
            showlistOfCheckpoints = true;
        }
        else {
            $('#listOfCheckpoints').css({
                'display': 'none',
            });
            showlistOfCheckpoints = false;
        }
    });

});