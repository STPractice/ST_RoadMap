'use strict'

var i = 1;
$(document).ready(function() {

    // $('#add').click(function(e) {
    //     var form = document.getElementById('createSkill');
    //     var block = document.getElementById('createSkill-block');
    //     var newBlock = block.cloneNode(true);
    //     newBlock.Id += i
    //     form.appendChild(newBlock);
    //     i++;
    // });


    $('#add').click(function(e) {
        $('#createSkill').append($('<div></div>')
            .addClass('createSkill-block')
            .attr('id', i)
            .html(`
                <div class="delete" id="delete${i}">X</div>
                    <div class="skillName">
                        <p>Name</p>
                        <input type="text" name="SkillLevels[${i}].Name" id="name" required>
                    </div>
                    <div class="description-block">
                        <p>Description</p>
                        <textarea name="SkillLevels[${i}].Description" id="description" cols="30" rows="10" class="description" required></textarea>
                    </div>
					<input type="hidden" name="SkillLevels[${i}].Level" value="${i}" />
            `)
        );
        i++;
    });

    $(document).on("click", ".delete", function() {
        var elem = this.id.substring(6, this.id.length);
        $('#' + elem).remove();
        i--;
    });
});
