import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchingFilter'
})
export class SearchingFilterPipe implements PipeTransform {

  transform(title: string, filterKey: string): unknown {
    if (!filterKey) {
      return title;
    }
    if (title.toUpperCase().includes(filterKey.toUpperCase())) {
      return title;
    }
    return null;
  }

}
