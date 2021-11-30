import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'padLeft'
})
export class PadLeftPipe implements PipeTransform {

  transform(value: string, character: string, length: number): string {
    if(value) {   
      const repeatCharacter = character.repeat(length);
      return String(repeatCharacter + value).slice(-length);
    } else {
      return '-';
    }
  }

}
