# Wishlist

Following are things I want to do. They're either former requirements or stretch goals from feature projects which I decided to defer or they're random things I thought of.

- [Wishlist](#wishlist)
  - [Autocomplete hover guide](#autocomplete-hover-guide)
  - [Autocomplete hide on focus lost](#autocomplete-hide-on-focus-lost)

## Autocomplete hover guide

When the user hovers over an autocomplete option (such as the title drop down), I want details about the selection to appear in a pop-up (or hovertext, tooltip, whatever).

I've tried using `CardDisplayCard` in a Bootstrap tooltip but it didn't work at all. The closest that got was printing "Cardalog.Shared.Components.CardDisplayCard" (i.e. the type) in a tooltip. I couldn't get it to render custom HTML, my Razor component, or anything else (not even a literal string...weird).

## Autocomplete hide on focus lost

When a user moves focus away from an autocomplete input, the autocomplete list should disappear. I tried using events like `onfocus` and `onfocusout` but it hid the list too aggressively - even when I tried to expand the drop down.

For example, when the user enters text into a card's title, the results box will appear if there's a match and it won't disappear if the user gives focus to another input. It only disappears if the user makes a selection or deletes the text.

I think this is related to how I'm using a Blazor `InputSelect` component, which renders as a drop down input. The input text box and the drop down are two separate components so it's hard to keep them in sync. I might have to hand-roll a textbox/dropdown which combines the functionality.
