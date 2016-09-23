//
//  WorldControl.swift
//  CGol
//
//  Created by Shawn Wallace on 9/22/16.
//  Copyright © 2016 Shawn Wallace. All rights reserved.
//

import UIKit

class WorldControl: UIView {
  let spacing = 3
  var cellSize = 15
  
  var width = 20
  var height = 25
  
  var cells = [UIButton]()

  required init?(coder aDecoder: NSCoder) {
    super.init(coder: aDecoder)
    
    fillButtons();
  }
  
  func redraw(){
    fillButtons()
  }
  
  func fillButtons(){
    let viewWidth = Int(self.frame.width)
    cellSize = (viewWidth + spacing) / width - spacing
    
    print("Drawing World: Columns: \(width) Rows: \(height) Cell Size: \(cellSize) ViewWidth: \(viewWidth)")
    
    cells = [UIButton]()
    
    for view in subviews {
      view.removeFromSuperview()
    }
    
    for _ in 0..<(width * height) {
      let button = UIButton()
      
      button.backgroundColor = UIColor.lightGray
      button.layer.borderColor = UIColor.black.cgColor
      button.layer.borderWidth = 1
      
      // button.addTarget(self, action: #selector(WorldControl.ratingButtonTapped(_:)), for: .touchDown)
      cells += [button]
      addSubview(button)
    }
  }
  
  override func layoutSubviews() {
    // Set the button's width and height to a square the size of the frame's height.
    var buttonFrame = CGRect(x: 0, y: 0, width: cellSize, height: cellSize)
    
    var index = 0
    for row in 0..<height {
      for column in 0..<width {
        let button = cells[index]
      
        // button.titleLabel = "A"
        buttonFrame.origin.x = CGFloat(column * (cellSize + spacing))
        buttonFrame.origin.y = CGFloat(row * (cellSize + spacing))
        button.frame = buttonFrame
        
        index += 1
      }
    }
  }
  
  override var intrinsicContentSize : CGSize {
    return CGSize(width: cellSize, height: cellSize)
  }
}
