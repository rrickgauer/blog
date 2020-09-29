This is an *incomplete* list of the MASM instruction set. I will be adding more instructions as I come across them for work. 

Kip Irvine published a great [book](http://index-of.es/Programming/Assembly/Assembly%20Language%20for%20x86%20Processors%206th%20Ed.pdf) that I use for reference. The complete instruction set is on page 652.

### Instructions Table



<div class="input-group mt-3 mb-3">
<div class="input-group-prepend">
<span class="input-group-text"><i class='bx bx-search'></i></span>
</div>
<input type="text" class="tablesearch-input form-control" data-tablesearch-table="#data-table" placeholder="Search table..." autofocus>
</div>






Instruction | Description 
:--- | :--- 
AAA | ascii adjust for addition 
AAD | ascii adjust for division 
AAM | ascii adjust for multiplication 
AAS | ascii adjust for subtraction 
ADC | Add carry
ADD | add 
AND | logical AND 
BOUND | check array bounds 
BSWAP | byte swap. reverses the byte order of a 32-bit destination register
CALL | Call a procedure 
CBW | convert byte to word 
CDQ | convert doubleword to quadword 
CLC | clear carry flag 
CLD | clear direction flag 
CLI | clear interrupt flag 
CMC | complement carry flag 
CMP | compare 
CMPS | compares two string in memory 
CWB | convert word to doubleword 
DAA | decimal adjust for addition 
DAS | decimal adjust for subtraction 
DEC | decrement 
DIV | unsigned integer division
IN | inputs a value from a hardware port 
INC | increment 
JA | jump if above 
JA | jump if destination above sour
JAE | jump if above or equal 
JAE | jump if destination above or equal to source
JB | jump if below 
JB | jump if destination below sour
JBE | jump if below or equal 
JBE | jump if destination below or equal to source
JC | jump if carry 
JCXZ | jump if CX equals zero 
JE | jump if destination equals sour
JE | jump if equal 
JG | jump if greater 
JG | jump if greater 
JGE | jump if greater or equal 
JGE | jump if greater or equal 
JL | jump if less 
JL | jump if less 
JLE | jump if less or equal 
JLE | jump if less or equal 
JNA | jump if not above 
JNAE | jump if not above or equal 
JNB | jump if not below 
JNBE | jump if not below or equal 
JNC | jump if no carry 
JNE | jump if destination not equal to sour
JNE | jump if not equal 
JNG | jump if not greater 
JNGE | jump if not greater or equal 
JNL | jump if not less 
JNLE | jump of not less than or equal 
JNO | jump if no overflow 
JNP | jump if no parity 
JNS | jump if not sign 
JNZ | jump if not zero 
JO | jump if overflow 
JP | jump if parity 
JPE | jump if parity equal 
JPO | jump if parity odd 
JS | jump if sign 
JZ | jump if zero 
LDS | load pointer using DS 
LES | load pointer using ES 
LODS | loads an element from a string 
LOOP | loop 
LOOPE | loop while equal 
LOOPNE | loop while not equal 
MOV | move 
MOVDW | copies a word 
MOVSB | copies a byte 
MOVSD | copies a doubleword 
MUL | unsigned integer multiply 
NEG | negate 
NOP | no operation 
NOT | logical NOT 
OR | inclusive OR 
OUT | outputs a value to a hardware port 
POP | pop from stack 
POPA | pop all 
PUSH | push on stack 
RCL | rotate carry left 
RCR | rotate carry right 
REP | repeat string 
REPE | repeat while equal 
REPNE | repeat while not equal 
RET | return from procedure 
ROL | rotate left 
ROR | rotate right 
SCAS | scans a string for an element 
SHL | shift left 
SHR | shift right 
STC | set carry flag 
STI | set interrupt flag 
STOS | stores an element into a string 
SUB | subtract 
TEST | test - tests individual bits 
XCHG | exchange two operands 
XLAT | translate using table 
XOR | exclusive or








<script>
    $(document).ready(function() {
        $('table').attr('id', 'data-table');
        $('table').addClass('tablesearch-table').addClass('tablesort');
    });
</script>