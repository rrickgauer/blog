This is an *incomplete* list of the MASM instruction set. I will be adding more instructions as I come across them for work. 

Kip Irvine published a great [book](http://index-of.es/Programming/Assembly/Assembly%20Language%20for%20x86%20Processors%206th%20Ed.pdf) that I use for reference.

### Instructions Table



<div class="input-group mt-3 mb-3">
<div class="input-group-prepend">
<span class="input-group-text"><i class='bx bx-search'></i></span>
</div>
<input type="text" class="tablesearch-input form-control" data-tablesearch-table="#data-table" placeholder="Search table..." autofocus>
</div>






Instruction | Description | Format
:--- | :--- | :---
AAA | ascii adjust for addition |  &nbsp;
AAD | ascii adjust for division |  &nbsp;
AAM | ascii adjust for multiplication |  &nbsp;
AAS | ascii adjust for subtraction |  &nbsp;
ADC | Add carry | &nbsp;
ADD | add |  &nbsp;
AND | logical AND |  &nbsp;
BOUND | check array bounds |  &nbsp;
BSWAP | byte swap. reverses the byte order of a 32-bit destination register | &nbsp;
CALL | Call a procedure |  &nbsp;
CBW | convert byte to word |  &nbsp;
CDQ | convert doubleword to quadword |  &nbsp;
CLC | clear carry flag |  &nbsp;
CLD | clear direction flag |  &nbsp;
CLI | clear interrupt flag |  &nbsp;
CMC | complement carry flag |  &nbsp;
CMP | compare |  &nbsp;
CMPS | compares two string in memory |  &nbsp;
CWB | convert word to doubleword |  &nbsp;
DAA | decimal adjust for addition |  &nbsp;
DAS | decimal adjust for subtraction |  &nbsp;
DEC | decrement |  &nbsp;
DIV | unsigned integer divide &nbsp;
IN | inputs a value from a hardware port |  &nbsp;
INC | increment |  &nbsp;
JA | jump if above |  &nbsp;
JA | jump if destination above source &nbsp;
JAE | jump if above or equal |  &nbsp;
JAE | jump if destination above or equal to source &nbsp;
JB | jump if below |  &nbsp;
JB | jump if destination below source &nbsp;
JBE | jump if below or equal |  &nbsp;
JBE | jump if destination below or equal to source &nbsp;
JC | jump if carry |  &nbsp;
JCXZ | jump if CX equals zero |  &nbsp;
JE | jump if destination equals source &nbsp;
JE | jump if equal |  &nbsp;
JG | jump if greater |  &nbsp;
JG | jump if greater |  &nbsp;
JGE | jump if greater or equal |  &nbsp;
JGE | jump if greater or equal |  &nbsp;
JL | jump if less |  &nbsp;
JL | jump if less |  &nbsp;
JLE | jump if less or equal |  &nbsp;
JLE | jump if less or equal |  &nbsp;
JNA | jump if not above |  &nbsp;
JNAE | jump if not above or equal |  &nbsp;
JNB | jump if not below |  &nbsp;
JNBE | jump if not below or equal |  &nbsp;
JNC | jump if no carry |  &nbsp;
JNE | jump if destination not equal to source &nbsp;
JNE | jump if not equal |  &nbsp;
JNG | jump if not greater |  &nbsp;
JNGE | jump if not greater or equal |  &nbsp;
JNL | jump if not less |  &nbsp;
JNLE | jump of not less than or equal |  &nbsp;
JNO | jump if no overflow |  &nbsp;
JNP | jump if no parity |  &nbsp;
JNS | jump if not sign |  &nbsp;
JNZ | jump if not zero |  &nbsp;
JO | jump if overflow |  &nbsp;
JP | jump if parity |  &nbsp;
JPE | jump if parity equal |  &nbsp;
JPO | jump if parity odd |  &nbsp;
JS | jump if sign |  &nbsp;
JZ | jump if zero |  &nbsp;
LDS | load pointer using DS |  &nbsp;
LES | load pointer using ES |  &nbsp;
LODS | loads an element from a string |  &nbsp;
LOOP | loop |  &nbsp;
LOOPE | loop while equal |  &nbsp;
LOOPNE | loop while not equal |  &nbsp;
MOV | move |  &nbsp;
MOVDW | copies a word |  &nbsp;
MOVSB | copies a byte |  &nbsp;
MOVSD | copies a doubleword |  &nbsp;
MUL | unsigned integer multiply |  &nbsp;
NEG | negate |  &nbsp;
NOP | no operation |  &nbsp;
NOT | logical NOT |  &nbsp;
OR | inclusive OR |  &nbsp;
OUT | outputs a value to a hardware port |  &nbsp;
POP | pop from stack |  &nbsp;
POPA | pop all |  &nbsp;
PUSH | push on stack |  &nbsp;
RCL | rotate carry left |  &nbsp;
RCR | rotate carry right |  &nbsp;
REP | repeat string |  &nbsp;
REPE | repeat while equal |  &nbsp;
REPNE | repeat while not equal |  &nbsp;
RET | return from procedure |  &nbsp;
ROL | rotate left |  &nbsp;
ROR | rotate right |  &nbsp;
SCAS | scans a string for an element |  &nbsp;
SHL | shift left |  &nbsp;
SHR | shift right |  &nbsp;
STC | set carry flag |  &nbsp;
STI | set interrupt flag |  &nbsp;
STOS | stores an element into a string |  &nbsp;
SUB | subtract |  &nbsp;
TEST | test - tests individual bits |  &nbsp;
XCHG | exchange two operands |  &nbsp;
XLAT | translate using table |  &nbsp;
XOR | exclusive or | &nbsp;








<script>
    $(document).ready(function() {
        $('table').attr('id', 'data-table');
        $('table').addClass('tablesearch-table').addClass('tablesort');
    });
</script>