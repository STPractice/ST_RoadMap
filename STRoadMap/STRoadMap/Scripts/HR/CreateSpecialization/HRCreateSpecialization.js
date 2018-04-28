'use strict'

var i;
$(document).ready(function () {
    i = document.getElementById("choosenSkillsCount").childNodes[0].textContent;
    $(document).on('click', '.add', function () {
        var addedSkill = document.getElementById(this.id.substring(3, this.id.length));
        var name = addedSkill.childNodes[1].textContent;
        var id = addedSkill.childNodes[2].textContent;

        var element = this.id.substring(3, this.id.length);       
        $('#' + element).remove();

        $('.chosen').append($('<div></div>')
            .addClass('skill')
            .attr('id', i)
            .html(`
           <p>${name}</p><p class="small">${id}</p>
           <div class="delete" id="delete${i}">Delete</div>
           <input type="hidden" name="Skills[${i}].SkillId" value="${id}" />
        `)
        );
        i++;
    });

    $(document).on('click', '.delete', function () {        
        var deletedSkill = document.getElementById(this.id.substring(6, this.id.length));
        var name = deletedSkill.childNodes[1].textContent;
        var id = deletedSkill.childNodes[2].textContent;

        var element = this.id.substring(6, this.id.length);
        $('#' + element).remove();

        $('.available').append($('<div></div>')
            .addClass('skill')
            .attr('id', i + 100)
            .html(`
           <p>${name}</p><p class="small">${id}</p>
           <div class="add" id="add${i + 100}">Add</div>
        `)
        );
        i--;
    });

});