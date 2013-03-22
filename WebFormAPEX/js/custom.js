$(function() {
     // Handler for .ready() called.
     $(".chosen").chosen();
     $( "#wucPrincipalForm1_txtPDBirthday" ).datepicker();
     $( "#wucPrincipalForm1_txtPDDateSpecimenCollect" ).datepicker();
     $( "#wucPrincipalForm1_txtGDBirthday" ).datepicker();
     $( "#wucPrincipalForm1_txtIDBirthday" ).datepicker();
     
     var select_count = 3;
     $(".chosen").change(add_test_selects);
     
    function add_test_selects() {
        
           //Get last insert of test table value
         var last_select_value = $('#table_tests select:last').val();
         
         
         if (last_select_value>0) {
            
                
                // This is your string :)
                var myString = '<td align="left">';
                    myString +='<select class="chosen" name="wucPrincipalForm1$ddlMedicalTest'+select_count+'" id="wucPrincipalForm1$ddlMedicalTest'+select_count+'" style="width:500px;">';
                    myString +='<option value="0">Select a Test</option>';
                    myString +='<option value="1">Blood</option>';
                    myString +='<option value="2">Urine</option>';
                    myString +='<option value="3">X-ray</option>';
                    myString +='<option value="4">Fluids</option>';
                    myString +='<option value="5">Test1</option>';
                    myString +='<option value="6">Test2</option>';
                    myString +='<option value="7">Test3</option>';
                    myString +='</select>';
                    myString +='</td>';
                    
                    myString +='<td width="80" align="left">';
                    myString +='<input type="text" style="width:100px;" id="wucPrincipalForm1_TextBox'+select_count+'1" maxlength="50" name="wucPrincipalForm1$TextBox'+select_count+'1">';
                    myString +='</td>';
                    myString +='<td width="80" align="left">';
                    myString +='<input type="text" style="width:100px;" id="wucPrincipalForm1_TextBox'+select_count+'2" maxlength="50" name="wucPrincipalForm1$TextBox'+select_count+'2">';
                    myString +='</td>';
                    myString +='<td width="80" align="left">';
                    myString +='<input type="text" style="width:100px;" id="wucPrincipalForm1_TextBox'+select_count+'3" maxlength="50" name="wucPrincipalForm1$TextBox'+select_count+'3">';
                    myString +='</td>';
                    myString +='<td width="80" align="left">';
                    myString +='<input type="text" style="width:100px;" id="wucPrincipalForm1_TextBox'+select_count+'4" maxlength="50" name="wucPrincipalForm1$TextBox'+select_count+'4">';
                    myString +='</td>';
                
                // This is a way to "htmlDecode" your string... see link below for details.    
                //myString = $("<tr />").html(myString);
                myTr = $('<tr/>', {
                            id: 'test_tr'+select_count,
                            className: '',
                            html: myString
                        });
                $(myTr).find('select').change(add_test_selects);
                
                // This is appending the html code to your div (which you don't have an ID for :P)
                $("#table_tests").append(myTr);
                
                $(".chosen").chosen();
                select_count++;
         
         }
        var total_selects = select_count-2;
         $("#total_selects").val(total_selects);
         
    }
     
     
    });